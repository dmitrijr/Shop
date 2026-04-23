using Microsoft.EntityFrameworkCore;
using Shop.Entities;

namespace Shop.Data
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInBasket> ProductInBaskets { get; set; }

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

            modelBuilder.Entity<ProductInBasket>(o =>
            {
                o.HasKey(e => e.Id);
                o.HasOne(e => e.Product)
                    .WithMany(e => e.ProductInBaskets)
                    .HasForeignKey(e => e.ProductId);
            });
        }
    }
}