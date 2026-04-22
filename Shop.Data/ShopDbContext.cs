using Microsoft.EntityFrameworkCore;
using Shop.Entities;

namespace Shop.Data
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(o =>
            {
                o.HasKey(e => e.Id);
                o.Property(e => e.Name).IsRequired();
                o.Property(e => e.Price).IsRequired();
            });
        }
    }
}