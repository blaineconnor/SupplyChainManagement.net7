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
    public class CompanyMapping : BaseEntityMapping<Company>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");
            builder.HasMany(e=>e.Departments).WithOne(e=>e.Company).HasForeignKey(e=>e.CompanyId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
