using System.Threading.Tasks;
using Moq;
using Shop.Repositories;

namespace Shop.Services.Tests
{
    public class ProductsServiceTests
    {
        [Theory]
        [InlineData(3, 3)]
        [InlineData(0, 10)]
        [InlineData(-14, 10)]
        [InlineData(20, 20)]
        public async Task Get_ExpectedDefaultItemsPerPage(int itemsPerPage, int expectedResult)
        {
            var realItemsPerPage = itemsPerPage;
            if (itemsPerPage <= 0)
                realItemsPerPage = ProductService.DefaultItemsPerPage;

            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock
                .Setup(o => o.GetAsync(It.IsAny<int>(), realItemsPerPage))
                .ReturnsAsync(() =>
                {
                    var products = new List<Entities.Product>();

                    for (int i = 0; i < realItemsPerPage; i++)
                        products.Add(new Entities.Product());

                    return products;
                });

            var productService = new ProductService(productRepositoryMock.Object);

            var actualProducts = await productService.GetAsync(1, itemsPerPage);
            Assert.Equal(expectedResult, actualProducts.Count);
        }
    }
}