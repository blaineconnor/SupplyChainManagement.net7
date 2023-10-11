using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.Application.Models.DTOs.Products;
using SCM.Application.Models.RequestModels.Products;
using SCM.Application.Services.Abstractions;
using SCM.Application.Wrapper;

namespace SCM.API.Controllers
{
    [ApiController]
    [Route("product")]

    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("get")]
        [Authorize(Policy = "EmployeePolicy")]
        public async Task<ActionResult<Result<List<ProductDTO>>>> GetAllProducts()
        {
            var categories = await _productService.GetAllProducts();
            return Ok(categories);
        }

        [HttpGet("get/{id:int}")]
        [Authorize(Policy = "EmployeePolicy")]
        public async Task<ActionResult<Result<ProductDTO>>> GetProductById(int id)
        {
            var category = await _productService.GetProductById(new GetProductByIdVM { Id = id });
            return Ok(category);
        }

        [HttpPost("create")]
        [Authorize(Policy = "PurchasingPolicy")]
        public async Task<ActionResult<Result<int>>> CreateProduct(CreateProductVM createProductVM)
        {
            var categoryId = await _productService.CreateProduct(createProductVM);
            return Ok(categoryId);
        }

        [HttpPut("update")]
        [Authorize(Policy = "EmployeePolicy")]
        public async Task<ActionResult<Result<int>>> UpdateProduct(int id, UpdateProductVM updateProductVM)
        {
            if (id != updateProductVM.Id)
            {
                return BadRequest();
            }
            var categoryId = await _productService.UpdateProduct(updateProductVM);
            return Ok(categoryId);
        }

        [HttpDelete("delete")]
        [Authorize(Policy = "EmployeePolicy")]
        public async Task<ActionResult<Result<int>>> DeleteProduct(int id)
        {
            var categoryId = await _productService.DeleteProduct(new DeleteProductVM { Id = id });
            return Ok(categoryId);
        }

    }
}
