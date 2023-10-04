using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;

namespace SCM.Persistence.Mappings
{
    public abstract class IdentityRoleMapping<T> : IEntityTypeConfiguration<T> where T : IdentityRole
    {
        public abstract void ConfigureDerivedEntityMapping(EntityTypeBuilder<T> builder);
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                 .HasColumnName("ID")
                .HasColumnOrder(1);

            ConfigureDerivedEntityMapping(builder);

            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasDefaultValueSql("0")
                .HasColumnOrder(30);
        }
    }
}
