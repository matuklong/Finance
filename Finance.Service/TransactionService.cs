using Finance.Data.Context;
using Finance.Model.Interface.Repository;
using Finance.Model.Interface.Common;
using Finance.Model.Model;
using Finance.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Service
{
    public class TransactionService : ServiceBase<Transaction, FinanceContext>, ITransactionService
    {
        private readonly ITransactionRepository _repository;
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionIdentificationRepository _transactionIdentificationRepository;

        public TransactionService(ITransactionRepository repository, IAccountRepository accountRepository, ITransactionIdentificationRepository transactionIdentificationRepository) : base(repository)
        {
            _repository = repository;
            _accountRepository = accountRepository;
            _transactionIdentificationRepository = transactionIdentificationRepository;
        }

        public async Task<Transaction> AddTransaction(int accountId, decimal value, DateTime transactionDate, string description,
            bool captalization, bool AccountTransfer, eTransactionType eTransactionType, string userid)
        {
            this.BeginTransaction();
            var account = await _accountRepository.GetUserAccount(userid, accountId);

            if (account == null)
                throw new Exception("Não foi possível localizar esta conta.");

            decimal tranValue = 0;

            switch (eTransactionType)
            {
                case eTransactionType.TransactionValue: tranValue = value; break;
                case eTransactionType.TotalValue: tranValue = value - account.BalanceValue; break;
            }

            if (description.Length > 50)
                description = description.Substring(0, 50);

            var transactionType = await _transactionIdentificationRepository.FindTransactionType(description, tranValue);
            var newTransaction = account.NewTransaction(tranValue, transactionDate, description, captalization, AccountTransfer, transactionType, userid);
            
            _repository.Add(newTransaction);
            await this.Commit();


            return newTransaction;
        }

        public async Task<Transaction> ChangeTransaction(int accountId, int transactionId, decimal value, DateTime transactionDate, string description,
            bool captalization, bool AccountTransfer, eTransactionType transactionType, string userid)
        {
            this.BeginTransaction();
            var account = await _accountRepository.GetUserAccount(userid, accountId);

            if (account == null)
                throw new Exception("Não foi possível localizar esta conta.");

            var ChangeTransaction = await _repository.GetUserTransaction(userid, transactionId);

            if (ChangeTransaction == null)
                throw new Exception("Não foi possível localizar a transação");
            
            decimal tranValue = 0;

            switch (transactionType)
            {
                case eTransactionType.TransactionValue: tranValue = value; break;
                case eTransactionType.TotalValue: tranValue = value - account.BalanceValue; break;
            }

            if (description.Length > 50)
                description = description.Substring(0, 50);

            account.ChangeMoviment(ChangeTransaction, tranValue, transactionDate, description, captalization, AccountTransfer);
            await this.Commit();
            return ChangeTransaction;

        }

        public async Task DeleteTransaction(int TransactionId, string userid)
        {
            this.BeginTransaction();

            var removeTransaction = await _repository.GetUserTransaction(userid, TransactionId);

            if (removeTransaction == null)
                throw new Exception("Não foi possível localizar a transação");

            var account = await _accountRepository.GetUserAccount(userid, removeTransaction.AccountId);

            if (account == null)
                throw new Exception("Não foi possível localizar esta conta.");

            
            account.RemoveMoviment(removeTransaction);
            _repository.Delete(removeTransaction);
            await this.Commit();
            return;
        }

        public async Task<ICollection<Transaction>> GetTransactionFromAccount(string userid, int accountId, DateTime fromDate)
        {
            var transactions = await _repository.GetTransactionFromAccountAndDate(userid, accountId, fromDate);
            if (!transactions.Any())
            {
                // If there is not transaction, get the last one.
                var lastTransaction = await _repository.GetLastTransactionFromAccount(userid, accountId);
                if (lastTransaction != null)
                    transactions.Add(lastTransaction);
            }

            return transactions;
        }

        public async Task<ICollection<object>> GetTransactionSummaryByMonth(string userid, DateTime fromDate)
        {
            return await _repository.GetTransactionSummaryByMonth(userid, fromDate);
        }

        public async Task<ICollection<Transaction>> GetTransactionFromDate(string userId, DateTime fromDate)
        {
            return await _repository.GetTransactionFromDate(userId, fromDate);
        }
    }
}
