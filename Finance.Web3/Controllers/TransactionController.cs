using Finance.Model.Interface.Common;
using Finance.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace Finance.Web3.Controllers
{
    [RoutePrefix("api/Transaction")]
    [Authorize]
    public class TransactionController : ApiController
    {
        // get the latest 2 months
        private DateTime BaseDate = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)).AddMonths(-2);
        private string userId = ""; 

        ITransactionService _transactionService;
        IAccountService _accountService;
        public TransactionController(ITransactionService transactionService, IAccountService accountService)
        {
            _transactionService = transactionService;
            _accountService = accountService;
            userId = this.User.Identity.GetUserId().ToString();
        }

        // GET: api/Transaction
        public async Task<IEnumerable<Transaction>> Get()
        {
            return await _transactionService.GetTransactionFromDate(userId, this.BaseDate);
        }

        // GET: api/Transaction/5
        public async Task<IEnumerable<Transaction>> Get(int id)
        {
            return await _transactionService.GetTransactionFromAccount(userId, id, this.BaseDate);
        }

        // POST: api/Transaction
        public async Task<object> Post([FromBody]Transaction transaction)
        {
            await _transactionService.AddTransaction(transaction.AccountId, transaction.TransactionValue, transaction.InclusionDate, transaction.TransactionDescription, transaction.Capitalization, transaction.AccountTransfer, eTransactionType.TransactionValue, userId);
            return new { Message = "Transação cadastrada com sucesso", Error = false };
        }

        // PUT: api/Transaction/5
        public async Task<object> Put([FromBody]Transaction transaction)
        {
            await _transactionService.ChangeTransaction(transaction.AccountId, transaction.TransactionId, transaction.TransactionValue, transaction.InclusionDate, transaction.TransactionDescription, transaction.Capitalization, transaction.AccountTransfer, eTransactionType.TransactionValue, userId);
            return new { Message = "Transação atualizada com sucesso", Error = false };
        }

        // DELETE: api/Transaction/5
        public async Task<object> Delete(int id)
        {
            await _transactionService.DeleteTransaction(id, userId);
            return new { Message = "Transação removida com sucesso", Error = false };
        }

        // GET: api/Transaction/GetSummary
        [Route("GetSummary")]
        public async Task<IEnumerable<object>> GetSummary()
        {
            return await _transactionService.GetTransactionSummaryByMonth(userId, this.BaseDate);
        }
    }
}
