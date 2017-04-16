using Finance.Data.Interfaces;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Data.Context
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable where TContext : IDbContext, new()
    {
        private readonly IContextManager<TContext> _contextManager = ServiceLocator.Current.GetInstance<ContextFactory<TContext>>().GetContextManager();
        //ServiceLocator.Current.GetInstance<IContextManager<TContext>>();// as ContextManager<TContext>;
        private readonly IDbContext _dbContext;
        private bool _disposed;

        public UnitOfWork()
        {
            _dbContext = _contextManager.GetContext();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                    _contextManager.Finish();
                }
            }
            _disposed = true;
        }
    }

}
