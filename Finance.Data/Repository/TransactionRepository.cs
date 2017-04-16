using Finance.Data.Context;
using Finance.Data.Repository.Common;
using Finance.Model.Interface.Repository;
using Finance.Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Data.Repository
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public async Task<ICollection<Transaction>> GetTransactionFromDate(string userId, DateTime fromDate)
        {
            var db = (FinanceContext)Context;
            return await db.Transactions.Include(x => x.TransactionType).Where(x => x.UserId == userId && x.TransactionDate >= fromDate).ToListAsync();
        }

        public async Task<ICollection<Transaction>> GetTransactionFromAccountAndDate(string userId, int AccountId, DateTime fromDate)
        {
            var db = (FinanceContext)Context;
            return await db.Transactions.Include(x => x.TransactionType).Where(x => x.UserId == userId && x.AccountId == AccountId && x.TransactionDate >= fromDate).ToListAsync();
        }

        public async Task<Transaction> GetLastTransactionFromAccount(string userId, int AccountId)
        {
            var db = (FinanceContext)Context;
            return await db.Transactions.Include(x => x.TransactionType).Where(x => x.UserId == userId && x.AccountId == AccountId).OrderByDescending(x => x.TransactionDate).FirstOrDefaultAsync();
        }

        public async Task<Transaction> GetUserTransaction(string userId, int transactionId)
        {
            var db = (FinanceContext)Context;
            return await db.Transactions.Include(x => x.TransactionType).Where(x => x.UserId == userId && x.TransactionId == transactionId).OrderByDescending(x => x.TransactionDate).FirstOrDefaultAsync();
        }

        public async Task<ICollection<object>> GetTransactionSummaryByMonth(string userid, DateTime fromDate)
        {
            var db = (FinanceContext)Context;
            return await db.Transactions
                .Where(x => x.UserId == userid && x.TransactionDate >= fromDate)
                .GroupBy(x => new { x.AccountId, x.TransactionDate.Year, x.TransactionDate.Month })
                .Select(x => new {
                    x.Key.AccountId,
                    x.Key.Year,
                    x.Key.Month,
                    ReceivedValue = x.Sum(y => y.TransactionValue > 0 ? y.TransactionValue : 0),
                    SendValue = x.Sum(y => y.TransactionValue < 0 ? y.TransactionValue : 0),
                    PeriodBalance = x.Sum(y => y.TransactionValue)
                })
                .OrderBy(x => new { x.AccountId, x.Year, x.Month })
                .ToListAsync<object>();
        }

    }
}
