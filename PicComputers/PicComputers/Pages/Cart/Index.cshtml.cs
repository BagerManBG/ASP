using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PicComputers.Data;
using PicComputers.Models;

namespace PicComputers.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly PicComputers.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;        

        public IndexModel(PicComputers.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;            
        }

        public IList<ProductCartMap> Maps { get; set; } = new List<ProductCartMap>();
        public const string MessageKey = nameof(MessageKey);
        public ApplicationUser CurrentUser { get; set; }

        [BindProperty]
        public Models.Order Order { get; set; }

        public async Task OnGetAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(HttpContext.User);
            float totalPrice = 0;

            Maps = await _context.ProductCartMap
                .Include(a => a.Product)
                .Include(a => a.Cart)
                .ThenInclude(a => a.Customer)
                .Where(a => a.Cart.Customer.Id == CurrentUser.Id)
                .ToListAsync();

            foreach (var map in Maps)
            {
                map.ProductTotalPrice = map.Product.Price * map.ProductQuantity;
                totalPrice += map.ProductTotalPrice;
            }

            if (Maps.Count > 0)
            {
                Maps.First().Cart.TotalPrice = totalPrice;
                _context.Attach(Maps.First().Cart).State = EntityState.Modified;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {            
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            CurrentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (Request.Form["Action"] == "DeleteProduct")
            {
                var productId = Convert.ToInt32(Request.Form["ProductId"]);

                var map = await _context.ProductCartMap
                    .Include(a => a.Product)
                    .Include(a => a.Cart)
                    .ThenInclude(a => a.Customer)
                    .Where(a => a.Cart.Customer.Id == CurrentUser.Id)
                    .Where(a => a.ProductId == productId)
                    .SingleOrDefaultAsync();

                if (map != null)
                {
                    var cart = map.Cart;
                    cart.TotalPrice -= map.Product.Price * map.ProductQuantity;

                    _context.Attach(cart).State = EntityState.Modified;
                    _context.ProductCartMap.Remove(map);
                    await _context.SaveChangesAsync();

                    TempData[MessageKey] = $"Product #{map.Product.ProductId} {map.Product.Name} Deleted!";
                }
            }
            else if (Request.Form["Action"] == "CreateOrder")
            {
                Order.DatePlaced = DateTime.Now;
                Order.CustomerId = CurrentUser.Id;                              

                var cartMaps = await _context.ProductCartMap
                    .Include(a => a.Product)
                    .Include(a => a.Cart)
                    .ThenInclude(a => a.Customer)
                    .Where(a => a.Cart.Customer.Id == CurrentUser.Id)
                    .ToListAsync();

                var cart = cartMaps[0].Cart;

                Order.TotalPrice = cart.TotalPrice;

                if (cartMaps.Count > 0)
                {
                    foreach (var cartMap in cartMaps)
                    {
                        var orderMap = new ProductOrderMap(
                            cartMap.ProductId,
                            cartMap.Product,
                            Order.OrderId,
                            Order);

                        orderMap.ProductQuantity = cartMap.ProductQuantity;

                        _context.ProductOrderMap.Add(orderMap);
                        _context.ProductCartMap.Remove(cartMap);
                    }

                    _context.Order.Add(Order);
                    _context.Cart.Remove(cart);

                    await _context.SaveChangesAsync();

                    TempData[MessageKey] = $"Order Placed!";
                }
            }

            return Redirect("/Cart");
        }
    }
}
