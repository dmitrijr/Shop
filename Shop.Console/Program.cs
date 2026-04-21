using Microsoft.Extensions.DependencyInjection;
using Shop.Entities;
using Shop.Repositories;
using Shop.Services;

namespace Shop.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var collection = new ServiceCollection();

            collection.AddScoped<IProductRepository, ProductRepository>();
            collection.AddScoped<IBasketRepository, BasketRepository>();
            collection.AddScoped<IProductService, ProductService>();

            var serviceProvider = collection.BuildServiceProvider();

            var productService = serviceProvider.GetRequiredService<IProductService>();

            var id = productService.Add(new Product()
            {
                Name = "Book",
                Price = 1.99M
            });

            var product = productService.Get(id);

            Console.WriteLine($"id: {product.Id}; name: {product.Name}");
        }
    }
}