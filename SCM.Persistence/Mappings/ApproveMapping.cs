using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;

namespace SCM.Persistence.Mappings
{
    public class ApproveMapping : AuditableEntityMapping<Approves>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Approves> builder)
        {
            builder.Property(x => x.RequestId)
                .HasColumnName("REQUEST_ID")
                .HasColumnOrder(3);

            builder.Property(x => x.DateTime)
                .HasColumnName("APPROVE_TIME")
                .HasColumnOrder(4)
                .HasColumnType("date");

            //builder.Property(x => x.IsApproved)
            //    .HasColumnName("IS_APPROVED")
            //    .HasColumnOrder(1);

            //builder.Property(x => x.IsDeleted)
            //    .HasColumnType("bit")
            //    .HasColumnName("IS_DELETED")
            //    .IsRequired(false);

            builder.ToTable("APPROVES");
        }
    }
}
