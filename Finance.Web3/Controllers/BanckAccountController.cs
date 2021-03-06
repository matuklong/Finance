﻿using Finance.Model.Interface.Common;
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
    [RoutePrefix("api/BankAccount")]
    [Authorize]
    public class BankAccountController : ApiController
    {
        private IAccountService _accountService;
        private string userId = "";

        public BankAccountController(IAccountService accountService)
        {
            _accountService = accountService;
            userId = this.User.Identity.GetUserId().ToString();
        }

        // GET: api/BanckAccount
        public async Task<IEnumerable<Account>> Get()
        {
            return await _accountService.GetAllAccounts(userId);
        }

        // GET: api/BanckAccount/5
        public async Task<Account> Get(int id)
        {
            return await _accountService.GetAccount(userId, id);
        }

        // POST: api/BanckAccount
        public async Task<object> Post([FromBody]Account account)
        {
            await _accountService.AddAccount(account.BankName, account.AccountAgency, account.AccountNumber, account.AccountDescription, userId);
            return new { Message = "Conta cadastrada com sucesso", Error = false };
        }

        // PUT: api/BanckAccount
        public async Task<object> Put([FromBody]Account account)
        {
            await _accountService.ChangeAccount(account.AccountId, account.BankName, account.AccountAgency, account.AccountNumber, account.AccountDescription, userId);
            return new { Message = "Conta atualizada com sucesso", Error = false };
        }

    }
}
