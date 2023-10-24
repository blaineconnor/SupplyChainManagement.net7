using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;
using System.Numerics;

namespace SCM.Persistence.Mappings
{
    public class OfferMapping : AuditableEntityMapping<Offer>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Offer> builder)
        {
            builder.Property(x => x.RequestId)
               .HasColumnName("REQUEST_ID")
               .HasColumnOrder(3)
               .IsRequired();

            builder.Property(x => x.Amount)
                .HasColumnName("AMOUNT")
                .HasColumnOrder(4)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            builder.Property(x => x.SupplierName)
                .HasColumnName("SUPPLIER_NAME")
                .HasColumnOrder(5)
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(50);

            builder.Property(x => x.SupplierId)
                .HasColumnName("SUPPLIER_ID")
                .HasColumnOrder(6);

            builder.Property(x => x.Status)
                .HasColumnName("OFFER_STATUS");

            builder.HasOne(e => e.Request)
                .WithMany(e => e.Offers)
                .HasForeignKey(e => e.RequestId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("OFFERS");
        }
    }
}
