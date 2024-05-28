using Microsoft.EntityFrameworkCore;
using PicPay.Core.Transfers.Interfaces.Repositories;
using PicPay.Core.Transfers.Models.Input;
using PicPay.Infrasctructure.Database;
using PicPay.Infrasctructure.Database.Models;

namespace PicPay.Core.Transfers.Repositories
{
    public class TransfersRepository(ApplicationDbContext dbContext) : ITransfersRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task Transfer(InTransfer transfer)
        {
            await _dbContext.Transactions
                .AddAsync(transfer);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            var result = await _dbContext.Transactions
                .OrderBy(tran => tran.TransactionDate)
                .Select(tran => new Transaction())
                .ToListAsync();

            return result;
        }
    }
}
