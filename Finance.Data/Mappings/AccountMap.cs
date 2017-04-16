using Finance.Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Data.Mappings
{
    class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            ToTable("Account");

            HasKey(t => t.AccountId);

            Property(a => a.UserId)
                .IsRequired()
                .HasMaxLength(50);

            Property(a => a.BankName)
                .IsRequired()
                .HasMaxLength(50);

            Property(a => a.AccountAgency)
                .IsRequired()
                .HasMaxLength(50);

            Property(a => a.AccountNumber)
                .IsRequired()
                .HasMaxLength(50);

            Property(a => a.BalanceValue)
                .IsRequired();

            Property(a => a.AccountDescription)
                .IsRequired()
                .HasMaxLength(50);

            Property(a => a.LastTransactionDate)
                .IsOptional();

            Property(a => a.Active)
                .IsOptional();
        }
    }
}
