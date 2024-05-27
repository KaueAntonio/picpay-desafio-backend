using PicPay.Core.Transfers.Models.Input;

namespace PicPay.Core.Transfers.Interfaces.Services
{
    public interface ITransfersService
    {
        Task Transfer(InTransfer transfer);
    }
}
