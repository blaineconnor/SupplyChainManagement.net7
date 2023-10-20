using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;

namespace SCM.Persistence.Mappings
{
    public class RequestMapping : AuditableEntityMapping<Request>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Request> builder)
        {
            builder.Property(x => x.Status)
                .HasColumnName("REQUEST_STATUS")
                .IsRequired();

            builder.Property(x => x.DateTime)
                .HasColumnName("CreatedDate");

            builder.Property(x => x.By)
                .HasColumnName("REQUEST_BY")
                .HasMaxLength(50);

            builder.Property(x => x.Amount)
                .HasColumnName("AMOUNT")
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            builder.Property(x => x.IsApproved)
                .HasColumnName("IS_APPROVED")
                .IsRequired();

            builder.ToTable("REQUESTS");
        }
    }
}
