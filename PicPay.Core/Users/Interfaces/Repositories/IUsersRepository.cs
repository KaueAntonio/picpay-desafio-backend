using PicPay.Infrasctructure.Database.Models;

namespace PicPay.Core.Users.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task<User> GetById(string id);
        Task<IEnumerable<User>> GetAll();
        Task Update(User user);
        Task Delete(User user);
        Task<User> Login(string username, string password);
    }
}
