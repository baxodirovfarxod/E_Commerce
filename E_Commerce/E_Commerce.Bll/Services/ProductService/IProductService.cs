using E_Commerce.Bll.Dtos.ProductDTOs;

namespace E_Commerce.Bll.Services.ProductService;

public interface IProductService
{
    Task<long> CreateProductAsync(ProductCreateDto productCreateDto);
    Task<ProductGetDto> GetProductByIdAsync(long productId);
    Task<List<ProductGetDto>> GetAllProductsAsync(int skip, int take);
    Task<ProductGetDto> UpdateProductAsync(ProductUpdateDto productUpdateDto);
    Task MarkProductAsDeletedAsync(long productId);
    Task<long> GetAllProductsCount();
}
