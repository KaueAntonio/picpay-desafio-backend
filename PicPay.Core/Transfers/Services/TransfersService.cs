using PicPay.Core.Transfers.Interfaces.Repositories;
using PicPay.Core.Transfers.Interfaces.Services;
using PicPay.Core.Transfers.Models.Input;

namespace PicPay.Core.Transfers.Services
{
    public class TransfersService(ITransfersRepository transfersRepository) : ITransfersService
    {
        private readonly ITransfersRepository _transfersRepository = transfersRepository;

        public async Task Transfer(InTransfer transfer)
        {
            await _transfersRepository.Transfer(transfer);
        }
    }
}
