using Shop.Entities;
using Shop.Repositories;

namespace Shop.Services
{
    public class ProductService : IProductService
    {
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
    }
}