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
    }
}
