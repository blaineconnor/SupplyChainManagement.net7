using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Persistence.Mappings
{
    public abstract class IdentityUserMapping<T> : IEntityTypeConfiguration<T> where T : IdentityUser
    {
        public abstract void ConfigureDerivedEntityMapping(EntityTypeBuilder<T> builder);
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                 .HasColumnName("ID")
                .HasColumnOrder(1);

            ConfigureDerivedEntityMapping(builder);

            builder.Property(x => x.UserName)
                .HasColumnName("USER_NAME")
                .HasDefaultValueSql("0")
                .HasColumnOrder(30);

            builder.Property(x => x.AccessFailedCount)
                .HasColumnName("ACCESS_FAILED")
                .HasColumnType("int");

            builder.Property(x=> x.TwoFactorEnabled)
                .HasColumnName("TWOFACTOR")
                .HasColumnType("bit");
            builder.Property(x=>x.PasswordHash)
                .HasColumnType("nvarchar(50)")
                .HasColumnName(@"Password");

        }
    }
}
