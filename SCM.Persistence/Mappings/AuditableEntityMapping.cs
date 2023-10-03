using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SCM.Domain.Common;

namespace SCM.Persistence.Mappings
{
    public abstract class AuditableEntityMapping<T> : IEntityTypeConfiguration<T> where T : AuditableEntity
    {
        public abstract void ConfigureDerivedEntityMapping(EntityTypeBuilder<T> builder);

        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .HasColumnOrder(1);

            ConfigureDerivedEntityMapping(builder);

            builder.Property(x => x.RequestTime)
                .HasColumnName("REQUEST_DATE")
                .HasColumnOrder(26);

            builder.Property(x => x.RequestedBy)
                .HasColumnName("REQUESTED_BY")
                .HasColumnType("nvarchar(10)")
                .IsRequired(false)
                .HasColumnOrder(27);

            builder.Property(x => x.BoughtTime)
                .HasColumnName("BOUGHT_DATE")
                .HasColumnOrder(28);

            builder.Property(x => x.BoughtBy)
                .HasColumnName("BOUGHT_BY")
                .HasColumnType("nvarchar(10)")
                .IsRequired(false)
                .HasColumnOrder(29);

            builder.Property(x => x.IsDeleted)
                .HasColumnName("IS_DELETED")
                .HasDefaultValueSql("0")
                .HasColumnOrder(30);
        }
    }
}
