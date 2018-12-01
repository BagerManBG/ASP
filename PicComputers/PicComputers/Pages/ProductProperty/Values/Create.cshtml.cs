using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PicComputers.Data;
using PicComputers.Models;

namespace PicComputers.Pages.ProductProperty.Values
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly PicComputers.Data.ApplicationDbContext _context;

        public CreateModel(PicComputers.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ProductPropertyId"] = new SelectList(_context.ProductProperty, "ProductPropertyId", "Name");
            return Page();
        }

        [BindProperty]
        public ProductPropertyValue ProductPropertyValue { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProductPropertyValue.Add(ProductPropertyValue);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}