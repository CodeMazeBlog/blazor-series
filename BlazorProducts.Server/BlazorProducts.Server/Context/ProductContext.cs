using BlazorProducts.Server.Context.Configuration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorProducts.Server.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        public DbSet<Product> Products { get; set; }
    }
}
