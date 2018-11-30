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
    public class IndexModel : PageModel
    {
        private readonly PicComputers.Data.ApplicationDbContext _context;

        public IndexModel(PicComputers.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.ProductProperty> ProductProperty { get;set; }

        public async Task OnGetAsync()
        {
            ProductProperty = await _context.ProductProperty.ToListAsync();
        }
    }
}
