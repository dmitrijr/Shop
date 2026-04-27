using Shop.Entities;

namespace Shop.Repositories
{
    public interface IProductRepository
    {
        int Create(Product product);
        Product Get(int id);
        void Update(Product product);
        void Delete(int id);
        List<Product> Get(int page, int itemsPerPage);
    }
}