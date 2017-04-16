using Finance.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Data.Context
{
    public class ServiceContextManager<TContext> : IContextManager<TContext> where TContext : IDbContext, new()
    {
        private IDbContext _context;

        public ServiceContextManager()
        {
            //_context = new TContext();
        }

        public IDbContext GetContext()
        {
            if (_context == null)
            {
                _context = new TContext();
            }

            return _context;
        }

        public void Finish()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
