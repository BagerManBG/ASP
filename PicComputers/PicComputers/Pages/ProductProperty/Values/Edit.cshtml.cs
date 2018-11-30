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

namespace PicComputers.Pages.ProductProperty.Values
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
        public ProductPropertyValue ProductPropertyValue { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductPropertyValue = await _context.ProductPropertyValue
                .Include(p => p.ProductProperty).FirstOrDefaultAsync(m => m.ProductPropertyValueId == id);

            if (ProductPropertyValue == null)
            {
                return NotFound();
            }
           ViewData["ProductPropertyId"] = new SelectList(_context.ProductProperty, "ProductPropertyId", "Key");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProductPropertyValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductPropertyValueExists(ProductPropertyValue.ProductPropertyValueId))
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

        private bool ProductPropertyValueExists(int id)
        {
            return _context.ProductPropertyValue.Any(e => e.ProductPropertyValueId == id);
        }
    }
}
