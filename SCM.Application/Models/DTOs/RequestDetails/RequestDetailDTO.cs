using SCM.Application.Models.DTOs.Categories;
using SCM.Application.Models.DTOs.Products;

namespace SCM.Application.Models.DTOs.RequestDetails
{
    public class RequestDetailDTO
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public CategoryDTO Category { get; set; }
        public ProductDTO Product { get; set; }
    }
}
