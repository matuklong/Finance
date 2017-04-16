using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Data.Interfaces
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : IDbContext, new()
    {
        void BeginTransaction();
        Task Commit();
    }
}
