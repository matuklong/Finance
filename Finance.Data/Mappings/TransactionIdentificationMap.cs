using Finance.Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Data.Mappings
{
    public class TransactionIdentificationMap : EntityTypeConfiguration<TransactionIdentification>
    {
        public TransactionIdentificationMap()
        {
            ToTable("TransactionIdentification");

            HasKey(t => t.TransactionIdentificationId);

            Property(c => c.UserId)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.TransactionValue)
                .IsOptional();

            HasRequired(t => t.TransactionType)
                .WithMany(tt => tt.TransactionIdentification)
                .HasForeignKey(t => t.TransactionTypeId);

        }
    }
}
