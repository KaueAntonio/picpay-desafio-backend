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

        public async Task AddBalance(string userID, decimal ammount)
        {
            var account = await _accountsRepository.GetByUserId(userID);

            account.UpdateBalance(ammount);

            await _accountsRepository.Update(account);
        }

        public async Task Create(string userId)
        {
            var newAccount = new BankAccount()
            {
                UserId = userId,
            };

            await _accountsRepository.Create(newAccount);
        }
    }
}
