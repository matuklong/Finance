using Finance.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Model.Interface.Common
{
    public interface IAccountService
    {
        Task<Account> AddAccount(string bankName, string accountAgency, string accountNumber, string accountDescription, string userid);
        Task<Account> ChangeAccount(int Id_Conta, string bankName, string accountAgency, string accountNumber, string accountDescription, string userid);
        Task<ICollection<Account>> GetAllAccounts(string userId);
        Task<Account> DeactivateAccount(int accountId, string userid);
        Task<Account> ActivateAccount(int accountId, string userid);
        Task<Account> GetAccount(string userId, int accountId);
    }
}
