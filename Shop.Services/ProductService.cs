using Shop.Entities;
using Shop.Repositories;

namespace Shop.Services
{
    public class ProductService : IProductService
    {
        public const int DefaultItemsPerPage = 10;

        public IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public int Create(Product product)
        {
            return productRepository.Create(product);
        }

        public Product Get(int id)
        {
            return productRepository.Get(id);
        }

        public void Update(Product product)
        {
            productRepository.Update(product);
        }

        public void Delete(int id)
        {
            productRepository.Delete(id);
        }

        public List<Product> Get(int page, int itemsPerPage)
        {
            if (page <= 0)
                page = 1;

            if (itemsPerPage <= 0)
                itemsPerPage = DefaultItemsPerPage;

            return productRepository.Get(page, itemsPerPage);
        }
    }
}