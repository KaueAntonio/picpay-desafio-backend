using PicPay.Core.Users.Interfaces.Services;
using PicPay.Core.Users.Interfaces.Repositories;
using PicPay.Core.Users.Models.Input;
using PicPay.Infrasctructure.Database.Models;
using Microsoft.AspNetCore.Identity;

namespace PicPay.Core.Users.Services
{
    public class UsersService(IUsersRepository usersRepository, UserManager<User> userManager) : IUsersService
    {
        private readonly IUsersRepository _usersRepository = usersRepository;
        private readonly UserManager<User> _userManager = userManager;

        public async Task Create(InUser user)
        {
            user.Validate();

            User newUser = user;

            var createResult = await _userManager.CreateAsync(newUser, newUser.Password);

            if (!createResult.Succeeded)
                throw new Exception(createResult.Errors.ToString());

            var roleResult = await _userManager.AddToRoleAsync(newUser, newUser.Role);

            if (!roleResult.Succeeded)
                throw new Exception(roleResult.Errors.ToString());
        }

        public async Task<User> GetById(string id)
        {
            var result = await _usersRepository.GetById(id);

            return result;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var result = await _usersRepository.GetAll();

            return result;
        }

        public async Task Update(User user)
        {
            await _usersRepository.Update(user);
        }

        public async Task Delete(User user)
        {
            await _usersRepository.Delete(user);
        }

    }
}
