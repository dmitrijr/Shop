using Shop.Entities;

namespace Shop.Services
{
    public interface IProductService
    {
        int Create(Product product);
        Product Get(int id);
        void Update(Product product);
        void Delete(int id);
    }
}