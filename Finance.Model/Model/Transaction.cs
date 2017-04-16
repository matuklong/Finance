using Finance.Model.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finance.Model.Model
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string UserId { get; set; }
        public int AccountId { get; set; }
        public Nullable<int> TransactionTypeId { get; set; }
        public decimal TransactionValue { get; set; }
        public System.DateTime InclusionDate { get; set; }
        public System.DateTime TransactionDate { get; set; }
        public string TransactionDescription { get; set; }
        public bool Capitalization { get; set; }
        public Nullable<decimal> BalanceBeforeTransaction { get; set; }
        public bool AccountTransfer { get; set; }

        public virtual Account Account { get; set; }
        public virtual TransactionType TransactionType { get; set; }


        public Transaction()
        {
        }

        public Transaction(Account account, decimal Transactionvalue, DateTime Transactiondate, string Transactiondescription,
            bool capitalization, bool accounttransfer, TransactionType transactionType, string userid)
        {
            account.LastTransactionDate = Transactiondate.Date;
            this.Account = account;
            this.UserId = userid;
            this.TransactionValue = Transactionvalue;
            this.InclusionDate = System.DateTime.Now;
            this.TransactionDate = Transactiondate.Date;
            this.TransactionDescription = Transactiondescription;
            this.Capitalization = capitalization;
            this.BalanceBeforeTransaction = account.BalanceValue;
            this.AccountTransfer = accounttransfer;
            this.ChamgeTransactionType(transactionType);

        }

        public void ChangeTransaction(decimal Transactionvalue, DateTime Transactiondate, string Transactiondescription,
            bool capitalization, bool accounttransfer)
        {
            this.TransactionValue = Transactionvalue;
            this.TransactionDate = Transactiondate.Date;
            this.TransactionDescription = Transactiondescription;
            this.Capitalization = capitalization;
            this.AccountTransfer = accounttransfer;
        }

        public void ChamgeTransactionType(TransactionType tipomovimento)
        {
            this.TransactionType = tipomovimento;
        }
    }
}
