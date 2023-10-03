using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;

namespace SCM.Persistence.Mappings
{
    public class RequestDetailMapping : AuditableEntityMapping<RequestDetail>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<RequestDetail> builder)
        {
            builder.Property(x => x.RequestId)
                .HasColumnName("REQUEST_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.ProductId)
                .HasColumnName("PRODUCT_ID")
                .HasColumnOrder(3);

            builder.Property(x => x.Quantity)
                .HasColumnName("QUANTITY")
                .HasColumnOrder(4);

            builder.Property(x => x.Price)
                .HasColumnName("PRICE")
                .HasColumnOrder(5);

            builder.HasOne(x => x.Request)
                .WithMany(x => x.RequestDetails)
                .HasForeignKey(x => x.RequestId)
                .HasConstraintName("REQUEST_DETAIL_REQUEST_REQUEST_ID");

            builder.ToTable("REQUEST_DETAILS");
        }
    }
}
