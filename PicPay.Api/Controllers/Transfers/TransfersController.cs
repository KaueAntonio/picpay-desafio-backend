using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PicPay.Core.Transfers.Interfaces.Services;
using PicPay.Core.Transfers.Models.Input;

namespace PicPay.Api.Controllers.Transfers
{
    [Route("transfer")]
    [Authorize(Roles = "Default")]
    public class TransfersController(ITransfersService transfersService) : ControllerBase
    {
        private readonly ITransfersService _transfersService = transfersService;

        [HttpPost]
        public async Task<IActionResult> Transfer([FromBody]InTransfer transfer)
        {
            await _transfersService.Transfer(transfer);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _transfersService.GetAll();

            return Ok(result);
        }
    }
}
