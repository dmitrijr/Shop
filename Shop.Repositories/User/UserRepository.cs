using Shop.Data;
using Shop.Entities;

namespace Shop.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ShopDbContext dbContext;

        public UserRepository(ShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public User GetByUsername(string username)
        {
            return dbContext.Users.SingleOrDefault(o => o.Username == username);
        }

        public int Create(User user)
        {
            var entityEntry = dbContext.Users.Add(user);

            dbContext.SaveChanges();

            return entityEntry.Entity.Id;
        }

        public void Update(User user)
        {
            dbContext.Users.Update(user);

            dbContext.SaveChanges();
        }
    }
}
