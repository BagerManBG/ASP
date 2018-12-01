using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public IndexModel(PicComputers.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Product> Product { get;set; }
        public IList<Models.Product> ProductsFinal { get; set; } = new List<Models.Product>();
        public IDictionary<string, string> PropertiesDict { get; set; } = new Dictionary<string, string>();       

        public async Task OnGetAsync(string search, int category)
        {
            var getParams = Request.Query.ToList();

            if (getParams.Count > 0)
            {
                var products = _context.Product
                    .Include(a => a.ProductCategory)
                    .Include(a => a.ProductPropertyMaps)
                    .ThenInclude(a => a.ProductPropertyValue);               

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
                    .ToListAsync();
            }

            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "ProductCategoryId", "Name");
            ViewData["Properties"] = _context.ProductProperty;
            ViewData["Values"] = _context.ProductPropertyValue.Include(a => a.ProductProperty);
        }
    }
}
