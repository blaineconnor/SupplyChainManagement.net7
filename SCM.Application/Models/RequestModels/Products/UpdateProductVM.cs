using System.Numerics;

namespace SCM.Application.Models.RequestModels.Products
{
    public class UpdateProductVM
    {
        public Int64 Id { get; set; }
        public Int64? CategoryId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public Int64? UnitInStock { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
