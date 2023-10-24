using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;

namespace SCM.Persistence.Mappings
{
    public class DepartmentMapping : BaseEntityMapping<Department>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("DEPARTMENT");
            builder.HasMany(e => e.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(e => e.Name)
                .HasColumnName("DEPARTMENT_NAME")
                .HasColumnType("nvarchar(70)")
                .HasMaxLength(70);

            builder.Property(e => e.Address)
                .HasColumnName("ADDRESS")
                .HasColumnType("nvarchar(70)")
                .HasMaxLength(70);
            builder.Property(e => e.Phone)
                .HasColumnName("PHONE")
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(20);
        }
    }
}
