using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PicComputers.Models;

namespace PicComputers.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PicComputers.Models.ProductCategory> ProductCategory { get; set; }
        public DbSet<PicComputers.Models.ProductProperty> ProductProperty { get; set; }
        public DbSet<PicComputers.Models.Product> Product { get; set; }
    }
}
