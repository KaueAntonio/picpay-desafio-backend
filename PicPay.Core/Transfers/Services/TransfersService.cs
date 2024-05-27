using PicPay.Core.Accounts.Interfaces.Services;
using PicPay.Core.Transfers.Interfaces.Repositories;
using PicPay.Core.Transfers.Interfaces.Services;
using PicPay.Core.Transfers.Models.Input;
using PicPay.Core.Users.Interfaces.Services;
using PicPay.Infrasctructure.Database.Models;

namespace PicPay.Core.Transfers.Services
{
    public class TransfersService(ITransfersRepository transfersRepository,
                                  IUsersService usersService,
                                  IAccountsService accountsService) : ITransfersService
    {
        private readonly ITransfersRepository _transfersRepository = transfersRepository;
        private readonly IUsersService _usersService = usersService;
        private readonly IAccountsService _accountsService = accountsService;

        public async Task Transfer(InTransfer transfer)
        {
            var payerAccount = await _accountsService.GetByUserId(transfer.Payer);

            var payeeAccount = await _accountsService.GetByUserId(transfer.Payee);

            CheckTransfer(transfer, payerAccount);

            payerAccount.UpdateBalance(-transfer.Value);
            payeeAccount.UpdateBalance(transfer.Value);

            await _accountsService.Update(payerAccount);
            await _accountsService.Update(payeeAccount);
        }

        private static void CheckTransfer(InTransfer transfer, BankAccount payerAccount)
        {
            if (payerAccount.Balance - transfer.Value < 0)
                throw new Exception("Insuficient Balance");

        }
    }
}
