using System.Numerics;

namespace SCM.Application.Models.RequestModels.Products
{
    public class CreateProductVM
    {
        public BigInteger? CategoryId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public BigInteger? UnitInStock { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
