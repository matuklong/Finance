using Finance.Data.Interfaces;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Data.Context
{
    public class ContextFactory<TContext> where TContext : IDbContext, new()
    {
        public IContextManager<TContext> GetContextManager()
        {
            return ServiceLocator.Current.GetInstance<ServiceContextManager<TContext>>();
        }
    }
}
