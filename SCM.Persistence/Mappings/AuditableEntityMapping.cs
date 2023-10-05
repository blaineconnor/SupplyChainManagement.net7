using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

            builder.Property(x => x.By)
                .HasColumnName("UPDATED_BY")
                .HasColumnOrder(27)
                .HasColumnType("NVARCHAR(10)")
                .IsRequired(false);

            builder.Property(x => x.DateTime)
                .HasColumnName("UPDATED_TIME")
                .HasColumnOrder(26);

            builder.Property(x => x.DateTime)
                .HasColumnName("REQUEST_TIME")
                .HasColumnOrder(26);

            builder.Property(x => x.By)
                .HasColumnName("REQUESTED_BY")
                .HasColumnType("nvarchar(10)")
                .IsRequired(false)
                .HasColumnOrder(27);

            builder.Property(x => x.DateTime)
                .HasColumnName("BOUGHT_DATE")
                .HasColumnOrder(28);

            builder.Property(x => x.By)
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
