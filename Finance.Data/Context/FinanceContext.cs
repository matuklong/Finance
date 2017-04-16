using Finance.Data.Mappings;
using Finance.Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Data.Context
{
    public class FinanceContext : DbContextBase
    {
        static FinanceContext()
        {
            Database.SetInitializer<FinanceContext>(null);
        }

        public FinanceContext()
            : base("FinanceConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ModelBuilderRemoveConventions(modelBuilder);
            ModelBuilderAddConfigurations(modelBuilder);
        }

        private void ModelBuilderRemoveConventions(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        private void ModelBuilderAddConfigurations(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new TransactionMap());
            modelBuilder.Configurations.Add(new TransactionIdentificationMap());
            modelBuilder.Configurations.Add(new TransactionTypeMap());
        }
        
        #region DBSets

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionIdentification> TransactionIdentifications { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        
        #endregion
    }
}
