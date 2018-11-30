using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PicComputers.Data;
using PicComputers.Models;

namespace PicComputers.Pages.ProductProperty
{
    public class CreateModel : PageModel
    {
        private readonly PicComputers.Data.ApplicationDbContext _context;

        public CreateModel(PicComputers.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.ProductProperty ProductProperty { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProductProperty.Add(ProductProperty);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}