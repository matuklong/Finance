using System;
using System.Collections.Generic;

namespace Finance.Model.Model
{
    public class TransactionType
    {

        public int TransactionTypeId { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TransactionIdentification> TransactionIdentification { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }

        public TransactionType()
        {
            this.TransactionIdentification = new HashSet<TransactionIdentification>();
            this.Transaction = new HashSet<Transaction>();
        }

        public TransactionType(string userid, string description) : base()
        {
            this.UserId = userid;
            this.Description = description;
        }
    }
}
