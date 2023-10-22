using System.Numerics;

namespace SCM.Application.Models.RequestModels.Departments
{
    public class UpdateDepartmentVM
    {
        public BigInteger Id { get; set; }
        public string DepartmentName { get; set; }
    }
}
