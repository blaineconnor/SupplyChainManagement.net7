using System.Numerics;

namespace SCM.Application.Models.RequestModels.Categories
{
    public class UpdateCategoryVM
    {
        public BigInteger Id { get; set; }
        public string CategoryName { get; set; }
    }
}
