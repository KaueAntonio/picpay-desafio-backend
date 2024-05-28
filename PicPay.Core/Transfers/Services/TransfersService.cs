using PicPay.Core.Accounts.Interfaces.Services;
using PicPay.Core.Transfers.Interfaces.Repositories;
using PicPay.Core.Transfers.Interfaces.Services;
using PicPay.Core.Transfers.Models.Input;
using PicPay.Core.Transfers.Models.Output;
using PicPay.Infrasctructure.Client.Interfaces.Services;
using PicPay.Infrasctructure.Database.Models;
using PicPay.Infrasctructure.Client.Models.Output;

namespace PicPay.Core.Transfers.Services
{
    public class TransfersService(ITransfersRepository transfersRepository,
                                  IAccountsService accountsService,
                                  IHttpClientService httpClientService) : ITransfersService
    {
        private readonly ITransfersRepository _transfersRepository = transfersRepository;
        private readonly IAccountsService _accountsService = accountsService;
        private readonly IHttpClientService _httpClientService = httpClientService;

        public async Task Transfer(InTransfer transfer)
        {
            var payerAccount = await _accountsService.GetByUserId(transfer.Payer);

            var payeeAccount = await _accountsService.GetByUserId(transfer.Payee);

           // await ValidateTransfer(transfer, payerAccount);

            payerAccount.UpdateBalance(-transfer.Value);
            payeeAccount.UpdateBalance(transfer.Value);

            await _accountsService.Update(payerAccount);
            await _accountsService.Update(payeeAccount);

            await _transfersRepository.Transfer(transfer);

           // await SendTransferNotification(transfer);
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            var result = await _transfersRepository.GetAll();

            return result;
        }

        private async Task ValidateTransfer(InTransfer transfer, BankAccount payerAccount)
        {
            if (payerAccount.Balance - transfer.Value < 0)
                throw new Exception("Insuficient Balance");

            var transAuth = await GetTransferAuthorization();

            if (transAuth.StatusCode != 200)
                throw new Exception("Error ocurred on validate transfer");

            if (transAuth.Data.Status != "success")
                throw new Exception("Unauthorized");
        }

        private async Task<OutClientResponse<OutTransferAuthService>> GetTransferAuthorization()
        {
            _httpClientService.Configure("TransferAuthUrl");

            var result = await _httpClientService.GetAsync<OutTransferAuthService>("authorize");

            return result;
        }

        private async Task SendTransferNotification(InTransfer transfer)
        {
            _httpClientService.Configure("TransferNotifyUrl");

            var result = await _httpClientService.PostAsync<OutTransferAuthService, InTransfer>("notify", transfer);

            if(result.StatusCode != 200)
                throw new Exception("Error ocurred on send transfer notification");
        }
    }
}
