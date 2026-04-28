namespace Shop.Services
{
    public interface IBasketService
    {
        int Add(int userId, int productId, int count);
    }
}