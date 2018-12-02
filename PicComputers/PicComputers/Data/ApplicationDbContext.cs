using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductProperty>()
                .HasMany(a => a.Values)
                .WithOne(a => a.ProductProperty)
                .HasForeignKey(a => a.ProductPropertyId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<ProductCategory>()
                .HasMany(a => a.Products)
                .WithOne(a => a.ProductCategory)
                .HasForeignKey(a => a.ProductCategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ProductPropertyMap>()
                .HasKey(a => new { a.ProductId, a.ProductPropertyValueId });

            modelBuilder.Entity<ProductPropertyMap>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.ProductPropertyMaps)
                .HasForeignKey(bc => bc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductPropertyMap>()
                .HasOne(bc => bc.ProductPropertyValue)
                .WithMany(c => c.ProductPropertyMaps)
                .HasForeignKey(bc => bc.ProductPropertyValueId);

            modelBuilder.Entity<ProductCartMap>()
                .HasKey(a => new { a.ProductId, a.CartId });

            modelBuilder.Entity<ProductCartMap>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.ProductCartMaps)
                .HasForeignKey(bc => bc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductCartMap>()
                .HasOne(bc => bc.Cart)
                .WithMany(c => c.ProductCartMaps)
                .HasForeignKey(bc => bc.CartId);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(p => p.Cart)
                .WithOne(i => i.Customer)
                .HasForeignKey<Cart>(b => b.UserId);

            modelBuilder.Entity<ProductOrderMap>()
                .HasKey(a => new { a.ProductId, a.OrderId });

            modelBuilder.Entity<ProductOrderMap>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.ProductOrderMaps)
                .HasForeignKey(bc => bc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductOrderMap>()
                .HasOne(bc => bc.Order)
                .WithMany(c => c.ProductOrderMaps)
                .HasForeignKey(bc => bc.OrderId);
        }

        public DbSet<PicComputers.Models.ProductCategory> ProductCategory { get; set; }
        public DbSet<PicComputers.Models.ProductProperty> ProductProperty { get; set; }
        public DbSet<PicComputers.Models.Product> Product { get; set; }
        public DbSet<PicComputers.Models.ProductPropertyValue> ProductPropertyValue { get; set; }
        public DbSet<PicComputers.Models.ProductPropertyMap> ProductPropertyMap { get; set; }
        public DbSet<PicComputers.Models.ApplicationUser> ApplicationUser { get; set; }
        public DbSet<PicComputers.Models.Cart> Cart { get; set; }
        public DbSet<PicComputers.Models.ProductCartMap> ProductCartMap { get; set; }
        public DbSet<PicComputers.Models.Order> Order { get; set; }
        public DbSet<PicComputers.Models.ProductOrderMap> ProductOrderMap { get; set; }
    }
}
