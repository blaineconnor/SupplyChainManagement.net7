using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;

namespace SCM.Persistence.Mappings
{
    public class SupplierMapping : AuditableEntityMapping<Supplier>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasColumnOrder(3)
                .HasMaxLength(30) 
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("EMAIL")
                .HasColumnOrder(4)
                .HasMaxLength(50)
                .IsRequired();

            builder.ToTable("SUPPLIERS");
        }
    }
}
