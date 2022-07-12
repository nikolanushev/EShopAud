using E_Shop.Domain.Domain_Models;
using E_Shop.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Shop.Repository
{
    public class ApplicationDbContext : IdentityDbContext<ShopApplicationUser>
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<ProductsInShoppingCart> ProductsInShoppingCart { get; set; }
        public virtual DbSet<ShopApplicationUser> ShopApplicationUsers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ProductsInOrder> ProductsInOrder { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProductsInShoppingCart>().HasKey(c => new { c.CartId, c.ProductId });
            builder.Entity<ProductsInOrder>().HasKey(c => new { c.OrderId, c.ProductId });
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
