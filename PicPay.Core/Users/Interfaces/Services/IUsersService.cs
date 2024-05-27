using PicPay.Core.Users.Models.Input;
using PicPay.Infrasctructure.Database.Models;

namespace PicPay.Core.Users.Interfaces.Services
{
    public interface IUsersService
    {
        Task Create(InUser user);
        Task<User> GetById(string id);
        Task<IEnumerable<User>> GetAll();
        Task Update(User user);
        Task Delete(User user);
    }
}
