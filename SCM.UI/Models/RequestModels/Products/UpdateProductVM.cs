namespace SCM.UI.Models.RequestModels.Products
{
    public class UpdateProductVM
    {
        public long Id { get; set; }
        public long? CategoryId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public long? UnitInStock { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
