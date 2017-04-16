using Finance.Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Data.Mappings
{
    class TransactionMap : EntityTypeConfiguration<Transaction>
    {
        public TransactionMap()
        {
            ToTable("Transaction");

            HasKey(t => t.TransactionId);

            Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.TransactionValue)
                .IsRequired();

            Property(t => t.InclusionDate)
                .IsRequired();

            Property(t => t.TransactionDate)
                .IsRequired();

            Property(t => t.TransactionDescription)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.Capitalization)
                .IsRequired();

            Property(t => t.BalanceBeforeTransaction)
                .IsRequired();

            Property(t => t.AccountTransfer)
                .IsRequired();

            HasOptional(t => t.TransactionType)
                .WithMany(tt => tt.Transaction)
                .HasForeignKey(t => t.TransactionTypeId);

            HasRequired(t => t.Account)
                .WithMany(tt => tt.Transaction)
                .HasForeignKey(t => t.AccountId);

        }
    }
}