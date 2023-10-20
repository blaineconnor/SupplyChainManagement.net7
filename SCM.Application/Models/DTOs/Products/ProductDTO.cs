using System.Numerics;

namespace SCM.Application.Models.DTOs.Products
{
    public class ProductDTO
    {
        public BigInteger Id { get; set; }
        public BigInteger CategoryId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public int UnitInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
