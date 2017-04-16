using Finance.Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Data.Mappings
{
    public class TransactionTypeMap :  EntityTypeConfiguration<TransactionType>
    {
        public TransactionTypeMap()
        {
            ToTable("TransactionType");

            HasKey(t => t.TransactionTypeId);

            Property(c => c.UserId)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(50);           


        }
    }
}
