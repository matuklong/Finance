using Finance.Data.Context;
using Finance.Model.Interface.Common;
using Finance.Model.Interface.Repository;
using Finance.Model.Model;
using Finance.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Service
{
    public class TransactionIdentificationService : ServiceBase<TransactionIdentification, FinanceContext>, ITransactionIdentificationService
    {
        private readonly ITransactionIdentificationRepository _repository;

        public TransactionIdentificationService(ITransactionIdentificationRepository repository) : base(repository)
        {
            _repository = repository;
        }

    }
}
