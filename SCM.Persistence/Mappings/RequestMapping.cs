using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;

namespace SCM.Persistence.Mappings
{
    public class RequestMapping : AuditableEntityMapping<Requests>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Requests> builder)
        {
            builder.Property(x => x.UserId)
                .HasColumnName("USER_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.RequestDate)
                .HasColumnName("REQUEST_DATE")
                .HasDefaultValueSql("getdate()")
                .HasColumnOrder(4);

            builder.Property(x => x.Status)
                .HasColumnName("REQUEST_STATUS")
                .HasColumnOrder(5);

            builder.Property(x => x.RequestedBy)
                .HasColumnName("REQUEST_BY")
                .HasColumnOrder(5);

            builder.ToTable("REQUESTS");
        }
    }
}
