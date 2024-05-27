using Microsoft.AspNetCore.Mvc;
using PicPay.Core.Transfers.Interfaces.Services;
using PicPay.Core.Transfers.Models.Input;

namespace PicPay.Api.Controllers.Transfers
{
    [Route("transfer")]
    public class TransfersController(ITransfersService transfersService) : ControllerBase
    {
        private readonly ITransfersService _transfersService = transfersService;

        [HttpPost]
        public async Task<IActionResult> Transfer([FromBody]InTransfer transfer)
        {
            await _transfersService.Transfer(transfer);

            return Ok();
        }
    }
}
