using System.Numerics;

namespace SCM.Application.Models.RequestModels.Companies
{
    public class UpdateCompanyVM
    {
        public BigInteger Id { get; set; }
        public string CompanyName { get; set; }
    }
}
