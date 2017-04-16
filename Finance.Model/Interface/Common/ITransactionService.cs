using Finance.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Model.Interface.Common
{
    public enum eTransactionType { TransactionValue, TotalValue };

    public interface ITransactionService : IService<Transaction>
    {
        Task<Transaction> AddTransaction(int accountId, decimal value, DateTime transactionDate, string description,
            bool captaçization, bool AccountTransfer, eTransactionType transactionType, string userid);

        Task<Transaction> ChangeTransaction(int accountId, int transactionId, decimal value, DateTime transactionDate, string description,
            bool captalization, bool AccountTransfer, eTransactionType transactionType, string userid);

        Task DeleteTransaction(int TransactionId, string userid);

        Task<ICollection<Transaction>> GetTransactionFromAccount(string userid, int accountId, DateTime fromDate);
        Task<ICollection<object>> GetTransactionSummaryByMonth(string userid, DateTime fromDate);
        Task<ICollection<Transaction>> GetTransactionFromDate(string userId, DateTime fromDate);

    }
}
