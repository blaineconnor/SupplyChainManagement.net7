using System.Numerics;

namespace SCM.Application.Models.RequestModels.Products
{
    public class CreateProductVM
    {
        public Int64? CategoryId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public int? UnitInStock { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
