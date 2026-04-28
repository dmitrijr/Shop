using Shop.Entities;
using Shop.Services.Models;

namespace Shop.Services
{
    public interface IProductService
    {
        int Create(CreateProduct product);
        Product Get(int id);
        void Update(Product createProduct);
        void Delete(int id);
        List<Product> Get(int page, int itemsPerPage);
    }
}