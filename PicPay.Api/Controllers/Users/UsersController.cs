using Microsoft.AspNetCore.Mvc;
using PicPay.Core.Users.Interfaces.Services;
using PicPay.Core.Users.Models.Input;

namespace PicPay.Api.Controllers.Users
{
    [Route("users")]
    public class UsersController(IUsersService usersService) : ControllerBase
    {
        private readonly IUsersService _usersService = usersService;

        public async Task<IActionResult> CreateUser([FromBody]InUser user)
        {
            await _usersService.CreateUser(user);

            return Ok();
        }
    }
}
