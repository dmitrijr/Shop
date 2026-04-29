using System.Threading.Tasks;
using Shop.Entities;
using Shop.Repositories;
using Shop.Services.Models;

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

        public int Create(CreateProduct createProduct)
        {
            var product = new Product()
            {
                Name = createProduct.Name,
                Price = createProduct.Price,
                CountInStock = createProduct.CountInStock
            };

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

        public async Task DeleteAsync(int id)
        {
            await productRepository.DeleteAsync(id);
        }

        public async Task<List<Product>> GetAsync(int page, int itemsPerPage)
        {
            if (page <= 0)
                page = 1;

            if (itemsPerPage <= 0)
                itemsPerPage = DefaultItemsPerPage;

            return await productRepository.GetAsync(page, itemsPerPage);
        }
    }
}