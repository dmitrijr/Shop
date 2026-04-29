using System.Threading.Tasks;
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

        public async Task DeleteAsync(int id)
        {
            await dbContext.Products.Where(o => o.Id == id).ExecuteDeleteAsync();

            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAsync(int page, int itemsPerPage)
        {
            return await dbContext.Products.Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToListAsync();
        }
    }
}