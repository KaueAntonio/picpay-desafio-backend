using PicPay.Core.Users.Interfaces.Services;
using PicPay.Core.Users.Interfaces.Repositories;
using PicPay.Core.Users.Models.Input;
using PicPay.Infrasctructure.Database.Models;
using Microsoft.AspNetCore.Identity;
using PicPay.Core.Accounts.Interfaces.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace PicPay.Core.Users.Services
{
    public class UsersService(IUsersRepository usersRepository,
                              UserManager<User> userManager,
                              IAccountsService accountsService,
                              IHttpContextAccessor httpContextAccessor,
                              RoleManager<IdentityRole> roleManager) : IUsersService
    {
        private readonly IUsersRepository _usersRepository = usersRepository;
        private readonly UserManager<User> _userManager = userManager;
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;
        private readonly IAccountsService _accountsService = accountsService;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

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

            await _accountsService.Create(newUser.Id);
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

        public async Task<User> Me()
        {
            var claims = _httpContextAccessor.HttpContext.User;

            string userId = claims.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var result = await _usersRepository.GetById(userId);

            return result;
        }

        public async Task ChangeRole(string role)
        {
            var claims = _httpContextAccessor.HttpContext.User;

            string userId = claims.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var user = await _usersRepository.GetById(userId);

            if (!await _roleManager.RoleExistsAsync(role))
                throw new Exception("Role not found");
            
            var roleResult = await _userManager.AddToRoleAsync(user, role);

            if (!roleResult.Succeeded)
                throw new Exception(roleResult.Errors.ToString());

            await _usersRepository.Update(user);
        }

    }
}
