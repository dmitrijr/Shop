using Shop.Entities;

namespace Shop.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private Dictionary<int, Basket> Baskets = new Dictionary<int, Basket>();

        public int Add(int userId, int productId, int count)
        {
            var basket = GetInstance(userId);
            AddBasketItem(basket, productId, count);
            return basket.Id;
        }

        public void Remove(int userId, int productId, int count)
        {
            var basket = GetInstance(userId);
            RemoveBasketItem(basket, productId, count);
        }

        public void RemoveAll(int userId, int productId)
        {
            var basket = GetInstance(userId);
            var product = basket.Products.Find(o => o.ProductId == productId);
            basket.Products.Remove(product);
        }

        public Basket Get(int userId)
        {
            return Baskets[userId];
        }

        private Basket GetInstance(int userId)
        {
            Baskets.TryGetValue(userId, out Basket basket);
            if (basket != null) return basket;

            var maxId = Baskets.Keys.Any() ? Baskets.Keys.Max() : 0;
            var newId = maxId + 1;
            var newBasket = new Basket()
            {
                UserId = userId,
                Id = newId,
                Products = new List<ProductInBasket> { }
            };
            Baskets.Add(userId, newBasket);
            return newBasket;
        }

        private void AddBasketItem(Basket basket, int productId, int count)
        {
            var product = basket.Products.Find(o => o.ProductId == productId);
            if (product != null) product.Count += count;

            else
            {
                var newProduct = new ProductInBasket
                {
                    BasketId = basket.Id,
                    ProductId = productId,
                    Count = count
                };
                basket.Products.Add(newProduct);
            }
        }

        private void RemoveBasketItem(Basket basket, int productId, int count)
        {
            var product = basket.Products.Find(o => o.ProductId == productId);
            if (product.Count > count) product.Count -= count;
            else basket.Products.Remove(product);
        }
    }
}