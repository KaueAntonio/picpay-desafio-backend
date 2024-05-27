using PicPay.Infrasctructure.Database.Models;

namespace PicPay.Core.Users.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task CreateUser(User user);
    }
}
