using PicPay.Core.Transfers.Models.Input;
using PicPay.Infrasctructure.Database.Models;

namespace PicPay.Core.Transfers.Interfaces.Repositories
{
    public interface ITransfersRepository
    {
        Task Transfer(InTransfer transfer);
        Task<IEnumerable<Transaction>> GetAll();
    }
}
