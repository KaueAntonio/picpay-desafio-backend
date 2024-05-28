using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PicPay.Core.Accounts.Interfaces.Services;

namespace PicPay.Api.Controllers.Account
{
    [Route("accounts")]
    public class AccountsController(IAccountsService accountsService) : ControllerBase
    {
        private readonly IAccountsService _accountsService = accountsService;

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByUserId([FromRoute]string userId)
        {
            var result = await _accountsService.GetByUserId(userId);

            return Ok(result);
        }

        [HttpPut("balance")]
        public async Task<IActionResult> AddBalance([FromQuery]string userId, [FromQuery]decimal ammount)
        {
            await _accountsService.AddBalance(userId, ammount);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery]string userId)
        {
            await _accountsService.Create(userId);

            return Ok();
        }
    }
}
