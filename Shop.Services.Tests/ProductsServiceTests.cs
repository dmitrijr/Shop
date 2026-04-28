using Moq;
using Shop.Repositories;

namespace Shop.Services.Tests
{
    public class ProductsServiceTests
    {
        [Fact]
        public void Get_ReturnsThreeItemsPerPage()
        {
            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock
                .Setup(o => o.Get(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<Entities.Product>());

            var productService = new ProductService(productRepositoryMock.Object);

            var actualProducts = productService.Get(1, 3);
            Assert.Equal(3, actualProducts.Count);
        }
    }
}