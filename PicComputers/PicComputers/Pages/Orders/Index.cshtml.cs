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

namespace PicComputers.Pages.Order
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly PicComputers.Data.ApplicationDbContext _context;

        public IndexModel(PicComputers.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Order
                .Include(o => o.Customer).ToListAsync();
        }
    }
}
