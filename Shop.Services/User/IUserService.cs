using Shop.Entities;

namespace Shop.Services
{
    public interface IUserService
    {
        User Login(string username, string password);
        bool ChangePassword(string username, string currentPassword, string newPassword);
        int Register(string username, string password);
    }
}
