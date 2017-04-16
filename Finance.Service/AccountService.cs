using Finance.Data.Context;
using Finance.Model.Interface.Common;
using Finance.Model.Interface.Repository;
using Finance.Model.Model;
using Finance.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Service
{
    public class AccountService : ServiceBase<Account, FinanceContext>, IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<Account> AddAccount(string bankName, string accountAgency, string accountNumber, string accountDescription, string userid)
        {
            this.BeginTransaction();
            var account = new Account(bankName, accountAgency, accountNumber, accountDescription, userid);
            _repository.Add(account);
            await this.Commit();
                
            return account;
        }

        public async Task<Account> ChangeAccount(int accountId, string bankName, string accountAgency, string accountNumber, string accountDescription, string userid)
        {
            this.BeginTransaction();
            var account = await _repository.GetUserAccount(userid, accountId);

            if (account == null)
                throw new Exception("Não foi possível localizar esta conta.");

            account.ChangeAccount(bankName, accountAgency, accountNumber, accountDescription);
            await this.Commit();
            return account;
        }

        public async Task<Account> DeactivateAccount(int accountId, string userid)
        {
            this.BeginTransaction();
            var account = await _repository.GetUserAccount(userid, accountId);

            if (account == null)
                throw new Exception("Não foi possível localizar esta conta.");

            account.DeactivateAccount();
            await this.Commit();
            return account;
        }

        public async Task<Account> ActivateAccount(int accountId, string userid)
        {
            this.BeginTransaction();
            var account = await _repository.GetUserAccount(userid, accountId);

            if (account == null)
                throw new Exception("Não foi possível localizar esta conta.");

            account.ActivateAccount();
            await this.Commit();
            return account;
        }

        public async Task<ICollection<Account>> GetAllAccounts(string userId)
        {
            return await _repository.GetActiveAccounts(userId);
        }
        public async Task<Account> GetAccount(string userId, int accountId)
        {
            return await _repository.GetUserAccount(userId, accountId);
        }
    }
}
