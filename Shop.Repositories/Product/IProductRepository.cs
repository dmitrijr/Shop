using Shop.Entities;

namespace Shop.Repositories
{
    public interface IProductRepository
    {
        int Create(Product product);
        Product Get(int id);
        void Update(Product product);
        Task DeleteAsync(int id);
        Task<List<Product>> GetAsync(int page, int itemsPerPage);
    }
}