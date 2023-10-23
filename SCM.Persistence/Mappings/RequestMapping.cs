using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;

namespace SCM.Persistence.Mappings
{
    public class RequestMapping : AuditableEntityMapping<Request>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Request> builder)
        {
            builder.Property(x => x.Id)                
                .IsRequired()
                .HasColumnName("ID");

            builder.Property(x => x.Status)
                .HasColumnName("REQUEST_STATUS")
                .IsRequired();

            builder.Property(x => x.AddedTime)
                .HasColumnName("CREATED_TIME");

            builder.Property(x => x.UpdatedTime)
                .HasColumnName("UPDATED_TIME");

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

            builder.HasOne(e => e.approves)
                .WithMany(e => e.Requests)
                .HasForeignKey(e => e.ApproverId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Offer)
                .WithMany(e => e.Requests)
                .HasForeignKey(e => e.OfferId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("REQUESTS");
        }
    }
}
