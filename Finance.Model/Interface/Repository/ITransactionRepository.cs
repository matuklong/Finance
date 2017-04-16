using Finance.Model.Interface.Common;
using Finance.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Model.Interface.Repository
{
    public interface ITransactionRepository : IRepository<Transaction>
    {

        Task<ICollection<Transaction>> GetTransactionFromDate(string userId, DateTime fromDate);
        Task<ICollection<Transaction>> GetTransactionFromAccountAndDate(string userId, int AccountId, DateTime fromDate);
        Task<Transaction> GetLastTransactionFromAccount(string userId, int AccountId);
        Task<Transaction> GetUserTransaction(string userId, int transactionId);
        Task<ICollection<object>> GetTransactionSummaryByMonth(string userid, DateTime fromDate);
    }
}
