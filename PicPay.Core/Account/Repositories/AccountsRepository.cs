using Microsoft.EntityFrameworkCore;
using PicPay.Core.Accounts.Interfaces.Repositories;
using PicPay.Infrasctructure.Database;
using PicPay.Infrasctructure.Database.Models;

namespace PicPay.Core.Accounts.Repositories
{
    public class AccountsRepository(ApplicationDbContext context) : IAccountsRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task Update(BankAccount account)
        {
            _context.BankAccounts
                .Update(account);

            await _context.SaveChangesAsync();
        }

        public async Task<BankAccount> GetByUserId(string userId)
        {
            var result = await _context.BankAccounts
                .FirstOrDefaultAsync(account => account.UserId == userId);

            return result;
        }
    }
}
