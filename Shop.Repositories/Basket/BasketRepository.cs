using System.Reflection.Metadata;
using Shop.Data;
using Shop.Entities;

namespace Shop.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly ShopDbContext dbContext;

        public BasketRepository(ShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Add(int userId, int productId, int count)
        {
            var basket = new Basket
            {
                UserId = userId,
                ProductInBaskets = new List<ProductInBasket>()
                {
                    new ProductInBasket
                    {
                        ProductId = productId,
                        Count = count
                    }
                }
            };

            var entityEntry = dbContext.Baskets.Add(basket);

            dbContext.SaveChanges();

            return entityEntry.Entity.Id;
            // var maxId = Baskets.Keys.Any() ? Baskets.Keys.Max() : 0;
            // var newId = maxId + 1;
            // var basket = new Basket()
            // {
            //     UserId = userId,
            //     ProductInBaskets = new()
            //     {
            //         new ProductInBasket()
            //         {
            //             BasketId = newId,
            //             ProductId = productId,
            //             Count = count
            //         }
            //     }
            // };

            // basket.Id = newId;

            // Baskets.Add(userId, basket);

            // return basket.Id;
        }

        public void Remove(int userId, int productId, int count)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll(int userId, int productId)
        {
            throw new NotImplementedException();
        }
    }
}