using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;

namespace SCM.Persistence.Mappings
{
    public class SupplierMapping : AuditableEntityMapping<Supplier>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Supplier> builder)
        {            
            builder.HasMany(e => e.Offers)
                .WithOne(e => e.Supplier)
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(e => e.SupplierName)
                .HasColumnName("SUPPLIER_NAME")
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(50);

            builder.Property(e => e.Email)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(e => e.Phone)
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(20);

            builder.ToTable("SUPPLIER");
        }
    }
}
