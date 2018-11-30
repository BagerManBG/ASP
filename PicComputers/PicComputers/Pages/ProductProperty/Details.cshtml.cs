using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PicComputers.Data;
using PicComputers.Models;

namespace PicComputers.Pages.ProductProperty
{
    public class DetailsModel : PageModel
    {
        private readonly PicComputers.Data.ApplicationDbContext _context;

        public DetailsModel(PicComputers.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
