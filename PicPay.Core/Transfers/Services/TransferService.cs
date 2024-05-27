using PicPay.Core.Transfers.Interfaces.Repositories;
using PicPay.Core.Transfers.Interfaces.Services;
using PicPay.Core.Transfers.Models.Input;

namespace PicPay.Core.Transfers.Services
{
    public class TransferService(ITransferRepository transferRepository) : ITransferService
    {
        private readonly ITransferRepository _transferRepository = transferRepository;

        public async Task Transfer(InTransfer transfer)
        {
            await _transferRepository.Transfer(transfer);
        }
    }
}
