using Shop.Data;
using Shop.Entities;

namespace Shop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopDbContext dbContext;

        public ProductRepository(ShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Add(Product product)
        {
            var entityEntry = dbContext.Products.Add(product);

            dbContext.SaveChanges();

            return entityEntry.Entity.Id;
        }

        public Product Get(int id)
        {
            return dbContext.Products.SingleOrDefault(o => o.Id == id);
        }
    }
}