using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PicComputers.Data;
using PicComputers.Models;

namespace PicComputers.Pages.ProductProperty.Values
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly PicComputers.Data.ApplicationDbContext _context;

        public DeleteModel(PicComputers.Data.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductPropertyValue = await _context.ProductPropertyValue.FindAsync(id);

            if (ProductPropertyValue != null)
            {
                _context.ProductPropertyValue.Remove(ProductPropertyValue);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
