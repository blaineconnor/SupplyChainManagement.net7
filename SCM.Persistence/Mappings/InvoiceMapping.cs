using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Persistence.Mappings
{
    public class InvoiceMapping : AuditableEntityMapping<Invoice>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(x => x.RequestId)
                .HasColumnName("REQUEST_ID")
                .HasColumnOrder(3)
                .IsRequired(); 

            builder.Property(x => x.SupplierId)
                .HasColumnName("SUPPLIER_ID")
                .HasColumnOrder(4)
                .IsRequired();

            builder.Property(x => x.SupplierName)
                .HasColumnName("SUPPLIER_NAME")
                .HasColumnOrder(4)
                .IsRequired();

            builder.Property(x => x.Amount)
                .HasColumnName("AMOUNT")
                .HasColumnOrder(4)
                .IsRequired();

            builder.Property(x => x.InvoiceDate)
                .HasColumnName("INVOICE_DATE")
                .HasColumnOrder(6)
                .HasColumnType("datetime")
                .IsRequired();

            builder.HasOne(x => x.Request)
               .WithMany(x => x.Invoices)
               .HasForeignKey(x => x.RequestId)
               .HasConstraintName("REQUEST_INVOICES_REQUESTID");


            builder.ToTable("INVOICES");
        }
    }
}
