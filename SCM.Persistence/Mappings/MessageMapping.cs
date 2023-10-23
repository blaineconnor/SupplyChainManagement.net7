using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;

namespace SCM.Persistence.Mappings
{
    public class MessageMapping : AuditableEntityMapping<Message>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Message> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("MESSAGE_ID");

            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Description)
                .HasColumnName("DESCRIPTION");

            builder.HasOne(e => e.Employee)
                .WithMany(e => e.messages)
                .HasForeignKey(e => e.UserId)
                .HasConstraintName("USER_ID")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.Companies)
                .WithOne(e => e.Messages)
                .HasForeignKey(e => e.Id)
                .HasConstraintName("COMPANY_ID")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.Departments)
                .WithOne(e => e.Messages)
                .HasForeignKey(e => e.Id)
                .HasConstraintName("DEPARTMENT_ID")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
