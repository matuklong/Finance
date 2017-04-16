using System;
using System.Collections.Generic;
using System.Linq;

namespace Finance.Model.Model
{
    public class Account
    {

        public int AccountId { get; set; }

        public string UserId { get; set; }
        public string BankName { get; set; }
        public string AccountAgency { get; set; }
        public string AccountNumber { get; set; }
        public decimal BalanceValue { get; set; }
        public string AccountDescription { get; set; }
        public Nullable<System.DateTime> LastTransactionDate { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Transaction> Transaction { get; set; }

        public Account()
        {
            this.Transaction = new HashSet<Transaction>();
        }

        public Account(string _BankName, string _AccountAgency, string _AccountNumber, string _AccountDescription, string userid) : base()
        {
            this.UserId = userid;
            this.BalanceValue = 0;
            this.Active = true;
            this.ChangeAccount(_BankName, _AccountAgency, _AccountNumber, _AccountDescription);
        }

        public void ChangeAccount(string _BankName, string _AccountAgency, string _AccountNumber, string _AccountDescription)
        {
            this.BankName = _BankName;
            this.AccountAgency = _AccountAgency;
            this.AccountNumber = _AccountNumber;
            this.AccountDescription = _AccountDescription;
        }

        public Transaction NewTransaction(decimal Transactionvalue, DateTime Transactiondate, string Transactiondescription,
            bool capitalization, bool accounttransfer, TransactionType transactionType, string userid)
        {
            Transaction _Mov = new Transaction(this, Transactionvalue, Transactiondate, Transactiondescription, capitalization, accounttransfer, transactionType, userid);
            
            this.BalanceValue += _Mov.TransactionValue;
            return _Mov;
        }

        public Transaction RemoveMoviment(Transaction mov)
        {
            this.BalanceValue -= mov.TransactionValue;
            this.Transaction.Remove(mov);
            return mov;
        }

        public Transaction ChangeMoviment(Transaction mov, decimal Transactionvalue, DateTime movimentdate, string Transactiondescription,
            bool capitalization, bool accounttransfer)
        {
            if (mov.TransactionValue != Transactionvalue)
            {
                // atualizar o saldo total da conta
                this.BalanceValue -= mov.TransactionValue;
                this.BalanceValue += Transactionvalue;
            }

            mov.ChangeTransaction(Transactionvalue, movimentdate, Transactiondescription, capitalization, accounttransfer);

            return mov;
        }

        public void DeactivateAccount()
        {
            if (this.Active)
                this.Active = false;
        }

        public void ActivateAccount()
        {
            if (!this.Active)
                this.Active = true;
        }
    }
}
