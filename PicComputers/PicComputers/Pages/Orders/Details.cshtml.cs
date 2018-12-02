using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PicComputers.Data;
using PicComputers.Models;

namespace PicComputers.Pages.Order
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly PicComputers.Data.ApplicationDbContext _context;

        public DetailsModel(PicComputers.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Order Order { get; set; }
        public IList<ProductOrderMap> Maps { get; set; } = new List<ProductOrderMap>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Order
                .Include(o => o.Customer).FirstOrDefaultAsync(m => m.OrderId == id);

            if (Order == null)
            {
                return NotFound();
            }

            var customer = Order.Customer;
            float totalPrice = 0;

            Maps = await _context.ProductOrderMap
                .Include(a => a.Product)
                .Include(a => a.Order)
                .ThenInclude(a => a.Customer)
                .Where(a => a.Order.Customer.Id == customer.Id)
                .ToListAsync();

            foreach (var map in Maps)
            {
                map.ProductTotalPrice = map.Product.Price * map.ProductQuantity;
                totalPrice += map.ProductTotalPrice;
            }

            if (Maps.Count > 0)
            {
                Maps.First().Order.TotalPrice = totalPrice;
                _context.Attach(Maps.First().Order).State = EntityState.Modified;
            }

            return Page();
        }
    }
}
