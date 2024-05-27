using PicPay.Core.Users.Interfaces.Repositories;
using PicPay.Infrasctructure.Database;
using PicPay.Infrasctructure.Database.Models;

namespace PicPay.Core.Users.Repositories
{
    public class UsersRepository(ApplicationDbContext dbContext) : IUsersRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task CreateUser(User user)
        {
            await _dbContext.Users.AddAsync(user);

            _dbContext.SaveChanges();
        }
    }
}
