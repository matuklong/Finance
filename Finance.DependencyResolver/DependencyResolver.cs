using Finance.Data.Context;
using Finance.Data.Interfaces;
using Finance.Data.Repository;
using Finance.Data.Repository.Common;
using Finance.Model.Interface.Common;
using Finance.Model.Interface.Repository;
using Finance.Service;
using Finance.Service.Common;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.DependencyResolver
{
    public static class FinanceDependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType(typeof(ContextFactory<>), typeof(ContextFactory<>));
            container.RegisterType(typeof(IContextManager<>), typeof(ServiceContextManager<>), new HierarchicalLifetimeManager());
            container.RegisterType(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            //RegisterApplicationResolver(container);
            RegisterServicesResolver(container);
            RegisterRepositoryResolver(container);
        }


        public static void ServiceResolve(UnityContainer container)
        {
            container.RegisterType(typeof(IContextManager<>), typeof(ServiceContextManager<>));
            container.RegisterType(typeof(IUnitOfWork<>), typeof(UnitOfWork<>), new HierarchicalLifetimeManager());

            RegisterRepositoryResolverDefault(container);
            RegisterServicesResolverDefault(container);

            container.RegisterType(typeof(IService<>), typeof(ServiceBase<,>));
            container.RegisterType(typeof(IRepository<>), typeof(RepositoryBase<>));
        }

        #region Services

        private static void RegisterServicesResolver(UnityContainer container)
        {
            container.RegisterType<IAccountService, AccountService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITransactionService, TransactionService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITransactionTypeService, TransactionTypeService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITransactionIdentificationService, TransactionIdentificationService>(new HierarchicalLifetimeManager());            
        }

        private static void RegisterServicesResolverDefault(UnityContainer container)
        {
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<ITransactionService, TransactionService>();
            container.RegisterType<ITransactionTypeService, TransactionTypeService>();
            container.RegisterType<ITransactionIdentificationService, TransactionIdentificationService>();
        }

        #endregion

        #region Repositories

        private static void RegisterRepositoryResolver(UnityContainer container)
        {
            container.RegisterType<IAccountRepository, AccountRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITransactionRepository, TransactionRepository>(new HierarchicalLifetimeManager());
            //container.RegisterType<ITransactionTypeRepository, TransactionTypeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITransactionIdentificationRepository, TransactionIdentificationRepository>(new HierarchicalLifetimeManager());
        }

        private static void RegisterRepositoryResolverDefault(UnityContainer container)
        {
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<ITransactionRepository, TransactionRepository>();
            //container.RegisterType<ITransactionTypeRepository, TransactionTypeRepository>();
            container.RegisterType<ITransactionIdentificationRepository, TransactionIdentificationRepository>();
        }

        #endregion
    }
}
