using PicPay.Core.Transfers.Models.Input;

namespace PicPay.Core.Transfers.Interfaces.Repositories
{
    public interface ITransfersRepository
    {
        Task Transfer(InTransfer transfer);
    }
}
