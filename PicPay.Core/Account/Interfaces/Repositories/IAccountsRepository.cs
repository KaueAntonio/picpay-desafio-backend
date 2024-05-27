using PicPay.Infrasctructure.Database.Models;

namespace PicPay.Core.Accounts.Interfaces.Repositories
{
    public interface IAccountsRepository
    {
        Task<BankAccount> GetByUserId(string userId);
        Task Update(BankAccount account);
    }
}
