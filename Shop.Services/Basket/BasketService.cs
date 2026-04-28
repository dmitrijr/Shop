using Shop.Repositories;

namespace Shop.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }

        public int Add(int userId, int productId, int count)
        {
            return basketRepository.Add(userId, productId, count);
        }
    }
}