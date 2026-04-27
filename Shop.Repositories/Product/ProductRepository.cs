using Microsoft.EntityFrameworkCore;
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

        public int Create(Product product)
        {
            var entityEntry = dbContext.Products.Add(product);

            dbContext.SaveChanges();

            return entityEntry.Entity.Id;
        }

        public Product Get(int id)
        {
            return dbContext.Products.SingleOrDefault(o => o.Id == id);
        }

        public void Update(Product product)
        {
            dbContext.Products.Update(product);

            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            // var product = Get(id);

            // dbContext.Products.Remove(product);
            // dbContext.SaveChanges();

            dbContext.Products.Where(o => o.Id == id).ExecuteDelete();

            dbContext.SaveChanges();
        }
    }
}