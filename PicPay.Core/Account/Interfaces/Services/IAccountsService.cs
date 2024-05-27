using PicPay.Infrasctructure.Database.Models;

namespace PicPay.Core.Accounts.Interfaces.Services
{
    public interface IAccountsService
    {
        Task<BankAccount> GetByUserId(string userId);
        Task Update(BankAccount account);
    }
}
