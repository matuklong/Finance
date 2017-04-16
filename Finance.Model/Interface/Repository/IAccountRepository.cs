using Finance.Model.Interface.Common;
using Finance.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Model.Interface.Repository
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<ICollection<Account>> GetActiveAccounts(string userId);
        Task<ICollection<Account>> GetAllAccounts(string userId);
        Task<Account> GetUserAccount(string userId, int accountId);
    }
}
