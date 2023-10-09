namespace SCM.Application.Models.RequestModels.RequestDetails
{
    public class CreateRequestDetailVM
    {
        public int RequestId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string RequestDescription { get; set; }
    }
}
