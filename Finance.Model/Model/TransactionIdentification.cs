using System;
using System.Collections.Generic;

namespace Finance.Model.Model
{
    public class TransactionIdentification
    {
        public int TransactionIdentificationId { get; set; }
        public string UserId { get; set; }
        public int TransactionTypeId { get; set; }
        public string Description { get; set; }
        public decimal? TransactionValue { get; set; }

        public virtual TransactionType TransactionType { get; set; }

        public TransactionIdentification()
        {

        }

        public TransactionIdentification(string userid, string description, decimal? Transactionvalue, TransactionType transactionType)
        {
            this.UserId = userid;
            this.Description = description;
            this.TransactionValue = Transactionvalue;
            this.TransactionType = transactionType;
        }

    }
}
