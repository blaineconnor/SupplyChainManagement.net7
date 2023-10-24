using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;

namespace SCM.Persistence.Mappings
{
    public class CompanyMapping : BaseEntityMapping<Company>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("COMPANY");
            builder.Property(x=>x.Id).IsRequired().HasColumnName("ID");
            builder.HasMany(e=>e.Departments)
                .WithOne(e=>e.Company)
                .HasForeignKey(e=>e.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("COMPANY_NAME")
                .HasColumnType("nvarchar(50)");            

            builder.Property(e => e.Phone)
                .HasColumnName("PHONE")
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)");

            builder.Property(e => e.Address)
                .HasColumnName("ADDRESS")
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            builder.Property(e => e.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");
        }
    }
}
