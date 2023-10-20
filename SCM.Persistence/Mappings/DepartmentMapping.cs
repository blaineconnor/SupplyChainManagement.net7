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
    public class DepartmentMapping : BaseEntityMapping<Department>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");
            //builder.HasOne(e=>e.Company).WithMany(e=>e.Departments).HasForeignKey(e=>e.CompanyId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
