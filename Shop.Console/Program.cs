using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data;
using Shop.Entities;
using Shop.Repositories;
using Shop.Services;

namespace Shop.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = BuildHost();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var dbContext = serviceProvider.GetRequiredService<ShopDbContext>();
                dbContext.Database.Migrate();

                var productService = serviceProvider.GetRequiredService<IProductService>();

                var id = productService.Add(new Product()
                {
                    Name = "Book2",
                    Price = 2.99M
                });

                var product = productService.Get(id);

                Console.WriteLine($"id: {product.Id}; name: {product.Name}");
            }
        }

        public static IHost BuildHost()
        {
            var host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

                services.AddDbContext<ShopDbContext>(options =>
                {
                    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                });

                services.AddScoped<IProductRepository, ProductRepository>();
                services.AddScoped<IBasketRepository, BasketRepository>();
                services.AddScoped<IProductService, ProductService>();
            });

            return host.Build();
        }

    }
}