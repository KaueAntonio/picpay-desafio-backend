using Microsoft.EntityFrameworkCore;
using PicPay.Core.Users.Interfaces.Repositories;
using PicPay.Infrasctructure.Database;
using PicPay.Infrasctructure.Database.Models;

namespace PicPay.Core.Users.Repositories
{
    public class UsersRepository(ApplicationDbContext dbContext) : IUsersRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<User> GetById(string id)
        {
            var result = await _dbContext.Users
                .FirstOrDefaultAsync(user => user.Id == id);

            return result;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var result = await _dbContext.Users
                .ToListAsync();

            return result;
        }

        public async Task Update(User user)
        {
            _dbContext.Users.Update(user);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _dbContext.Users.Remove(user);

            await _dbContext.SaveChangesAsync();
        }
    }
}
