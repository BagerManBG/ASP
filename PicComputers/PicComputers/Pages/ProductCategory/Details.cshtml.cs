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

namespace PicComputers.Pages.ProductCategory
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly PicComputers.Data.ApplicationDbContext _context;

        public DetailsModel(PicComputers.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.ProductCategory ProductCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductCategory = await _context.ProductCategory.FirstOrDefaultAsync(m => m.ProductCategoryId == id);

            if (ProductCategory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
