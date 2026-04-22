using Shop.Entities;

namespace Shop.Repositories
{
    public interface IBasketRepository
    {
        int Add(int userId, int productId, int count);
        void Remove(int userId, int productId, int count);
        void RemoveAll(int userId, int productId);
        Basket Get(int userId);
    }
}