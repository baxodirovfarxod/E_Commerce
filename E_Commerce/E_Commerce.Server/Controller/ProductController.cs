using E_Commerce.Bll.Dtos.ProductDTOs;
using E_Commerce.Bll.Services.ProductService;
using E_Commerce.Server.Filters;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Server.Controller
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService ProductService;
        public ProductController(IProductService productService)
        {
            ProductService = productService;
        }

        [HttpPost("create")]
        public Task<long> CreateProductAsync(ProductCreateDto productCreateDto)
        {
            return ProductService.CreateProductAsync(productCreateDto);
        }

        [HttpGet("get")]
        public Task<ProductGetDto> GetProductByIdAsync(long productId)
        {
            return ProductService.GetProductByIdAsync(productId);
        }

        [HttpGet("getAll")]
        [ServiceFilter(typeof(ProductCountHeaderFilter))]
        public Task<List<ProductGetDto>> GetAllProductsAsync(int skip, int take)
        {
            return ProductService.GetAllProductsAsync(skip, take);
        }

        [HttpPut("update")]
        public Task<ProductGetDto> UpdateProductAsync(ProductUpdateDto productUpdateDto)
        {
            return ProductService.UpdateProductAsync(productUpdateDto);
        }

        [HttpDelete("delete")]
        public async Task MarkProductAsDeletedAsync(long productId)
        {
            await ProductService.MarkProductAsDeletedAsync(productId);
        }
    }
}
