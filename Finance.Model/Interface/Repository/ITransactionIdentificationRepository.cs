using Finance.Model.Interface.Common;
using Finance.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Model.Interface.Repository
{
    public interface ITransactionIdentificationRepository : IRepository<TransactionIdentification>
    {
        Task<TransactionType> FindTransactionType(string description, decimal value);
    }
}
