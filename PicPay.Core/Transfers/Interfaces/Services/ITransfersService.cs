using PicPay.Core.Transfers.Models.Input;
using PicPay.Infrasctructure.Database.Models;

namespace PicPay.Core.Transfers.Interfaces.Services
{
    public interface ITransfersService
    {
        Task Transfer(InTransfer transfer);
        Task<IEnumerable<Transaction>> GetAll();
    }
}
