using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PicComputers.Data;
using PicComputers.Models;

namespace PicComputers.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private readonly PicComputers.Data.ApplicationDbContext _context;

        public DetailsModel(PicComputers.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Product Product { get; set; }
        public IDictionary<string, string> PropertiesDict { get; set; } = new Dictionary<string, string>();

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

            Product.ProductCategory = await _context.ProductCategory.FindAsync(Product.ProductCategoryId);

            var products = _context.Product.Include(a => a.ProductPropertyMaps);
            foreach (Models.Product product in products)
            {
                if (product.ProductId == id)
                {
                    foreach (ProductPropertyMap map in product.ProductPropertyMaps)
                    {
                        var value = await _context.ProductPropertyValue
                            .FindAsync(map.ProductPropertyValueId);

                        var property = await _context.ProductProperty
                            .FindAsync(value.ProductPropertyId);

                        PropertiesDict.TryGetValue(property.Name, out string v);

                        if (v == null)
                        {
                            PropertiesDict.Add(property.Name, value.Value);
                        }
                        else
                        {
                            v = $"{v}, {value.Value}";
                            PropertiesDict[property.Name] = v;
                        }                            
                    }
                }
            }

            ViewData["PropertiesDict"] = PropertiesDict;

            return Page();
        }
    }
}
