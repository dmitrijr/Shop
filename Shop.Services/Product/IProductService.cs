using Shop.Entities;
using Shop.Services.Models;

namespace Shop.Services
{
    public interface IProductService
    {
        int Create(CreateProduct product);
        Product Get(int id);
        void Update(Product createProduct);
        Task DeleteAsync(int id);
        Task<List<Product>> GetAsync(int page, int itemsPerPage);
    }
}