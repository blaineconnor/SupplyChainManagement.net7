using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Persistence.Mappings
{
    public class RoleMapping : IdentityRoleMapping<Role>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                 .HasColumnName("ID")
                .HasColumnOrder(1);
            builder.Property(x => x.RoleName)
                .HasColumnName("RoleName");
            builder.Property(x=> x.Name)
                .HasColumnName("Name")
                .HasColumnOrder(2);
            builder.HasKey(x => x.RoleId);
            builder.Property(x => x.RoleId)
                .HasColumnOrder(1)
                .HasColumnName("RoleId");
            builder.Property(x => x.DateCreated)
                .HasColumnName("DateCreated")
                .HasColumnType("int");
        }
    }
}
