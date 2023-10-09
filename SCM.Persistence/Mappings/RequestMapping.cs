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
                            .HasMaxLength(255)
                            .IsRequired();

            builder.Property(x => x.RequestDate)
                .HasColumnName("REQUEST_DATE")
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnName("REQUEST_STATUS")
                .IsRequired();

            builder.Property(x => x.By)
                .HasColumnName("REQUEST_BY")
                .HasMaxLength(255);

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
