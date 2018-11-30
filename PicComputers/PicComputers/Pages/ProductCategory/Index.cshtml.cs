using System;
using System.Collections.Generic;
using System.Data;
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
    public class IndexModel : PageModel
    {
        private readonly PicComputers.Data.ApplicationDbContext _context;

        public IndexModel(PicComputers.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.ProductCategory> ProductCategory { get;set; }

        public async Task OnGetAsync()
        {
            ProductCategory = await _context.ProductCategory.ToListAsync();
        }
    }
}
