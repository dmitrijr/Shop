using Microsoft.AspNetCore.Identity;
using Shop.Entities;
using Shop.Repositories;

namespace Shop.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher<User> passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
        }

        public User Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            var user = userRepository.GetByUsername(username);
            if (user == null)
                return null;

            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (result == PasswordVerificationResult.Failed)
                return null;

            if (result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                user.PasswordHash = passwordHasher.HashPassword(user, password);
                userRepository.Update(user);
            }

            return user;
        }

        public bool ChangePassword(string username, string currentPassword, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
                return false;

            var user = userRepository.GetByUsername(username);
            if (user == null)
                return false;

            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, currentPassword);
            if (result == PasswordVerificationResult.Failed)
                return false;

            user.PasswordHash = passwordHasher.HashPassword(user, newPassword);
            userRepository.Update(user);

            return true;
        }

        public int Register(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Username and password are required.");

            var existing = userRepository.GetByUsername(username);
            if (existing != null)
                throw new InvalidOperationException("Username already exists.");

            var user = new User
            {
                Username = username
            };
            user.PasswordHash = passwordHasher.HashPassword(user, password);

            return userRepository.Create(user);
        }
    }
}
