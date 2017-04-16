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
    public class TransactionIdentificationRepository : RepositoryBase<TransactionIdentification>, ITransactionIdentificationRepository
    {
        public async Task<TransactionType> FindTransactionType(string description, decimal value)
        {
            var db = (FinanceContext)Context;            
            return await (from o in db.TransactionIdentifications
                       where(
                                    (o.Description.Length > 1 && description.Trim().Contains(o.Description.Trim()))
                                    || (o.Description.Length == 1 && description.Trim() == o.Description.Trim())
                                    || o.Description == null
                             )
                             && (value == o.TransactionValue || o.TransactionValue == null)
                    select o.TransactionType).FirstOrDefaultAsync();
    }

    }
}
