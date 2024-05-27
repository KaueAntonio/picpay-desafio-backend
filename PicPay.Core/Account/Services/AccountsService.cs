using PicPay.Core.Accounts.Interfaces.Repositories;
using PicPay.Core.Accounts.Interfaces.Services;
using PicPay.Infrasctructure.Database.Models;

namespace PicPay.Core.Accounts.Services
{
    public class AccountsService(IAccountsRepository accountsRepository) : IAccountsService
    {
        private readonly IAccountsRepository _accountsRepository = accountsRepository;

        public async Task Update(BankAccount account)
        {
            await _accountsRepository.Update(account);
        }

        public async Task<BankAccount> GetByUserId(string userId)
        {
            var result = await _accountsRepository.GetByUserId(userId);

            return result;
        }
    }
}
