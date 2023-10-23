using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;
using System.Numerics;

namespace SCM.Persistence.Mappings
{
    public class ApproveMapping : AuditableEntityMapping<Approves>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Approves> builder)
        {
            builder.Property(x => x.ApproveId)                
                .HasColumnName("APPROVED_ID")
                .IsRequired();

            builder.Property(x => x.RequestId)                
                .HasColumnName("REQUEST_ID");


            builder.Property(x => x.Status)
                .HasColumnName("STATUS")
                .HasColumnOrder(6)
                .IsRequired();

            builder.Property<Int64>(x => x.Id)                
                .HasColumnName("ID")
                .HasColumnOrder(7);

            builder.ToTable("APPROVES");
        }
    }
}
