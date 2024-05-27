using PicPay.Core.Users.Interfaces.Services;
using PicPay.Core.Users.Interfaces.Repositories;
using PicPay.Core.Users.Models.Input;
using PicPay.Infrasctructure.Database.Models;

namespace PicPay.Core.Users.Services
{
    public class UsersService(IUsersRepository usersRepository) : IUsersService
    {
        private readonly IUsersRepository _usersRepository = usersRepository;

        public async Task CreateUser(InUser user)
        {
            User newUser = user;

            await _usersRepository.CreateUser(newUser);
        }
    }
}
