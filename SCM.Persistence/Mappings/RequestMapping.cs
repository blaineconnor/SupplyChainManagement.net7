using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;

namespace SCM.Persistence.Mappings
{
    public class RequestMapping : AuditableEntityMapping<Requests>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Requests> builder)
        {
            builder.Property(x => x.UserName)
                .HasColumnName("USER_NAME")
                .HasColumnOrder(2);

            builder.Property(x => x.RequestDate)
                .HasColumnName("REQUEST_DATE")
                .HasDefaultValueSql("getdate()")
                .HasColumnOrder(4);

            builder.Property(x => x.Status)
                .HasColumnName("REQUEST_STATUS")
                .HasColumnOrder(5);

            builder.Property(x => x.By)
                .HasColumnName("REQUEST_BY")
                .HasColumnOrder(5);

            builder.Property(x => x.Amount)
                .HasColumnName("AMOUNT")
                .HasColumnOrder(8);

            builder.Property(x => x.IsApproved)
                .HasColumnName("IS_APPROVED");

            builder.ToTable("REQUESTS");
        }
    }
}
