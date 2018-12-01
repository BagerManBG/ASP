using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PicComputers.Data;
using PicComputers.Models;

namespace PicComputers.Pages.Product
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly PicComputers.Data.ApplicationDbContext _context;

        public EditModel(PicComputers.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IEnumerable<bool> Values { get; set; }

        [BindProperty]
        public Models.Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FirstOrDefaultAsync(m => m.ProductId == id);

            if (Product == null)
            {
                return NotFound();
            }

            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "ProductCategoryId", "Name");
            ViewData["Properties"] = _context.ProductProperty;

            IList<ProductPropertyValue> ValuesList = new List<ProductPropertyValue>();

            var values = _context.ProductPropertyValue.Include(a => a.ProductProperty);

            for (int i = 0; i < values.Count(); i++)
            {
                ProductPropertyValue value = values.ToList()[i];

                var map = await _context.ProductPropertyMap
                    .FindAsync(Product.ProductId, value.ProductPropertyValueId);

                if (map != null)
                {
                    value.isSelected = true;
                }
                
                ValuesList.Add(value);
            }

            ViewData["Values"] = ValuesList;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var maps = _context.ProductPropertyMap
                .Where(a => a.ProductId == Product.ProductId);

            _context.ProductPropertyMap.RemoveRange(maps);

            foreach (var value in _context.ProductPropertyValue)
            {
                if (Request.Form[value.Key].Count > 0)
                {
                    var map = new ProductPropertyMap(Product.ProductId, Product, value.ProductPropertyValueId, value);
                    _context.ProductPropertyMap.Add(map);
                }
            }

            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
