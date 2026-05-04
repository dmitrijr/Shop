using Shop.Entities;

namespace Shop.Repositories
{
    public interface IUserRepository
    {
        User GetByUsername(string username);
        int Create(User user);
        void Update(User user);
    }
}
