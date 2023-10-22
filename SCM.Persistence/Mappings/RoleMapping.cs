using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;

namespace SCM.Persistence.Mappings
{
    public class RoleMapping : AuditableEntityMapping<Role>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("ROLE");
            builder.HasMany(e => e.Accounts)
                .WithOne(e => e.Role)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.Suppliers)
                .WithOne(e => e.Role)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("ROLE_NAME");
        }
    }
}
