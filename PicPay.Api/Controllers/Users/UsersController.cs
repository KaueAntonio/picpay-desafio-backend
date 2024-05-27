using Microsoft.AspNetCore.Mvc;
using PicPay.Core.Users.Interfaces.Services;
using PicPay.Core.Users.Models.Input;
using PicPay.Infrasctructure.Database.Models;

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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            await _usersService.Update(user);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]User user)
        {
            await _usersService.Delete(user);

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
    }
}
