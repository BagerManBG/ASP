using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PicComputers.Data;
using PicComputers.Models;

namespace PicComputers.Pages.ProductProperty
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
        public Models.ProductProperty ProductProperty { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductProperty = await _context.ProductProperty.FirstOrDefaultAsync(m => m.ProductPropertyId == id);

            if (ProductProperty == null)
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

            ProductProperty = await _context.ProductProperty.FindAsync(id);

            if (ProductProperty != null)
            {
                _context.ProductProperty.Remove(ProductProperty);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
