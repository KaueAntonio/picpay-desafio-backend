using PicPay.Core.Transfers.Models.Input;

namespace PicPay.Core.Transfers.Interfaces.Repositories
{
    public interface ITransferRepository
    {
        Task Transfer(InTransfer transfer);
    }
}
