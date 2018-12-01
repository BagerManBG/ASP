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
    public class CreateModel : PageModel
    {
        private readonly PicComputers.Data.ApplicationDbContext _context;

        public CreateModel(PicComputers.Data.ApplicationDbContext context)
        {            
            _context = context;          
        }

        [BindProperty]
        public IEnumerable<bool> Values { get; set; }

        [BindProperty]
        public Models.Product Product { get; set; }

        public IActionResult OnGet()
        {
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "ProductCategoryId", "Name");
            ViewData["Properties"] = _context.ProductProperty;
            ViewData["Values"] = _context.ProductPropertyValue.Include(a => a.ProductProperty);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {    
            if (!ModelState.IsValid)
            {
                return Page();
            }   
            
            foreach (var value in _context.ProductPropertyValue)
            {
                if (Request.Form[value.Key].Count > 0)
                {
                    var map = new ProductPropertyMap(Product.ProductId, Product, value.ProductPropertyValueId, value);
                    _context.ProductPropertyMap.Add(map);
                }
            }

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}