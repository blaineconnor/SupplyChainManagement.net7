namespace SCM.UI.Models.DTOs.Products
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public int UnitInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
