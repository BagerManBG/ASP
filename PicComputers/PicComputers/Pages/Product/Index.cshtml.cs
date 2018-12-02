using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PicComputers.Data;
using PicComputers.Models;

namespace PicComputers.Pages.Product
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

        public IList<Models.Product> Product { get;set; }
        public IList<Models.Product> ProductsFinal { get; set; } = new List<Models.Product>();
        public IDictionary<string, string> PropertiesDict { get; set; } = new Dictionary<string, string>();
        public int ProductId { get; set; }
        public const string MessageKey = nameof(MessageKey);

        public async Task OnGetAsync(string search, int category)
        {
            var getParams = Request.Query.ToList();
            int paramCount = getParams.Count;

            var s = getParams.Find(a => a.Key == "search");
            var c = getParams.Find(a => a.Key == "category");

            if (s.Value.Count > 0)
            {
                paramCount--;
            }

            if (c.Value.Count > 0)
            {
                paramCount--;
            }

            if (paramCount > 0)
            {
                var products = _context.Product
                    .Include(a => a.ProductCategory)
                    .Include(a => a.ProductPropertyMaps)
                    .ThenInclude(a => a.ProductPropertyValue)
                    .Where(a => a.ProductCategory.ProductCategoryId == (c.Value.Count > 0 ? category : a.ProductCategory.ProductCategoryId))
                    .Where(a => a.Name.Contains((s.Value.Count > 0 ? search : a.Name)));

                foreach (var getParam in getParams)
                {
                    if (getParam.Key != "search" && getParam.Key != "category")
                    {
                        var value = _context.ProductPropertyValue
                            .Where(a => a.Key == getParam.Key);

                        if (value.Count() > 0)
                        {
                            foreach (var product in products)
                            {
                                var mapCount = product.ProductPropertyMaps.Where(a => a.ProductPropertyValueId == value.Single().ProductPropertyValueId).Count();

                                if (mapCount > 0)
                                {
                                    if (!ProductsFinal.Any(a => a.ProductId == product.ProductId))
                                    {
                                        ProductsFinal.Add(product);
                                    }                                    
                                }
                            }
                        }
                    }
                }

                Product = ProductsFinal;
            } 
            else
            {
                Product = await _context.Product
                    .Include(a => a.ProductCategory)
                    .Where(a => a.ProductCategory.ProductCategoryId == (category > 0 ? category : a.ProductCategory.ProductCategoryId))
                    .Where(a => a.Name.Contains((s.Value.Count > 0 ? search : a.Name)))
                    .ToListAsync();
            }

            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "ProductCategoryId", "Name");
            ViewData["Properties"] = _context.ProductProperty;
            ViewData["Values"] = _context.ProductPropertyValue.Include(a => a.ProductProperty);
        }

        [Authorize]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            ProductId = Convert.ToInt32(Request.Form["ProductId"]);
            var product = await _context.Product.FindAsync(ProductId);

            var cart = await _context.Cart
                .Include(a => a.Customer)
                .Where(a => a.UserId == currentUser.Id)
                .SingleOrDefaultAsync();

            if (cart == null)
            {
                cart = new Models.Cart();
                cart.UserId = currentUser.Id;
                cart.Customer = currentUser;
            }

            cart.TotalPrice += product.Price;

            var map = await _context.ProductCartMap
                .Where(a => a.CartId == cart.CartId)
                .Where(a => a.ProductId == ProductId)
                .SingleOrDefaultAsync();

            if (map == null)
            {
                map = new ProductCartMap(ProductId, product, cart.CartId, cart);
                await _context.ProductCartMap.AddAsync(map);
            }
            else
            {
                map.ProductQuantity++;
                _context.Attach(map).State = EntityState.Modified;
            }
            
            await _context.SaveChangesAsync();            

            TempData[MessageKey] = $"Product #{product.ProductId} {product.Name}";

            return Redirect("/Product" + Request.QueryString);
        }
    }
}
