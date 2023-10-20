using System.Numerics;

namespace SCM.Application.Models.DTOs.RequestDetail
{
    public class RequestDetailDTO
    {
        public BigInteger Id { get; set; }
        public decimal Quantity { get; set; }
        public BigInteger ProductId { get; set; }
        public string ProductName { get; set; }
        public BigInteger RequestId { get; set; }
    }
}
