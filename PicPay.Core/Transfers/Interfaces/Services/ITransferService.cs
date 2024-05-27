using PicPay.Core.Transfers.Models.Input;

namespace PicPay.Core.Transfers.Interfaces.Services
{
    public interface ITransferService
    {
        Task Transfer(InTransfer transfer);
    }
}
