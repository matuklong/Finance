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
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public async Task<ICollection<Account>> GetActiveAccounts(string userId)
        {
            var db = (FinanceContext)Context;
            return await db.Accounts.Where(x => x.UserId == userId && x.Active).ToListAsync();
        }

        public async Task<ICollection<Account>> GetAllAccounts(string userId)
        {
            var db = (FinanceContext)Context;
            return await db.Accounts.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Account> GetUserAccount(string userId, int accountId)
        {
            var db = (FinanceContext)Context;
            return await db.Accounts.Where(x => x.UserId == userId && x.AccountId == accountId).FirstOrDefaultAsync();
        }
    }
}
