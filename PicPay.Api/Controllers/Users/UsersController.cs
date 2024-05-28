using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PicPay.Core.Users.Interfaces.Services;
using PicPay.Core.Users.Models.Input;

namespace PicPay.Api.Controllers.Users
{
    [Route("users")]
    public class UsersController(IUsersService usersService) : ControllerBase
    {
        private readonly IUsersService _usersService = usersService;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]InUser user)
        {
            await _usersService.Create(user);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]string id)
        {
            var result = await _usersService.GetById(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _usersService.GetAll();

            return Ok(result);
        }

        [HttpGet("me")]
        [Authorize(Roles = "Default")]
        public async Task<IActionResult> Me()
        {
            var result = await _usersService.Me();

            return Ok(result);
        }

        [HttpPost("role")]
        public async Task<IActionResult> ChangeRole([FromQuery]string role)
        {
            await _usersService.ChangeRole(role);

            return Ok();
        }
    }
}
