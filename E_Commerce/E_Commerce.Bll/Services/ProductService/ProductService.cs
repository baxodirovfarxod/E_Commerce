using AutoMapper;
using E_Commerce.Bll.Dtos.ProductDTOs;
using E_Commerce.Dal.Entities;
using E_Commerce.Repository.Repositories.ProductRepository;
using FluentValidation;

namespace E_Commerce.Bll.Services.ProductService;

public class ProductService : IProductService
{
    private readonly IProductRepository ProductRepository;
    private readonly IMapper Mapper;
    private readonly IValidator<ProductCreateDto> ProductCreateDtoValidator;
    private readonly IValidator<ProductUpdateDto> ProductUpdateDtoValidator;


    public ProductService(IProductRepository productRepository, IMapper mapper, IValidator<ProductCreateDto> productCreateDtoValidator, IValidator<ProductUpdateDto> productUpdateDtoValidator)
    {
        ProductRepository = productRepository;
        Mapper = mapper;
        ProductCreateDtoValidator = productCreateDtoValidator;
        ProductUpdateDtoValidator = productUpdateDtoValidator;
    }

    public async Task<long> CreateProductAsync(ProductCreateDto productCreateDto)
    {
        var validationResult = await ProductCreateDtoValidator.ValidateAsync(productCreateDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var product = await ProductRepository.ExistsByNameAsync(productCreateDto.Name);
        if (product)
        {
            throw new Exception("Product with this name already exists");
        }

        var productEntity = Mapper.Map<Product>(productCreateDto);

        var productId = await ProductRepository.InsertProductAsync(productEntity);

        return productId;
    }

    public async Task MarkProductAsDeletedAsync(long productId)
    {
        var product = await ProductRepository.SelectProductByIdAsync(productId);
        if (product == null)
        {
            throw new Exception("Product not found");
        }

        await ProductRepository.SoftDeleteProductAsync(productId);
    }

    public async Task<List<ProductGetDto>> GetAllProductsAsync(int skip, int take)
    {
        var products = await ProductRepository.SelectAllProductsAsync(skip, take);

        if (products == null || products.Count == 0)
        {
            throw new Exception("No products found");
        }

        return Mapper.Map<List<ProductGetDto>>(products);

    }

    public async Task<ProductGetDto> GetProductByIdAsync(long productId)
    {
        var product = await ProductRepository.SelectProductByIdAsync(productId);

        if (product == null)
        {
            throw new Exception("Product not found");
        }

        return Mapper.Map<ProductGetDto>(product);
    }

    public async Task<ProductGetDto> UpdateProductAsync(ProductUpdateDto productUpdateDto)
    {
        var validationResult = await ProductUpdateDtoValidator.ValidateAsync(productUpdateDto);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var product = await ProductRepository.SelectProductByIdAsync(productUpdateDto.ProductId);

        if (product == null)
        {
            throw new Exception("Product not found");
        }

        Mapper.Map(productUpdateDto, product);

        await ProductRepository.UpdateProductAsync(product);

        return Mapper.Map<ProductGetDto>(product);
    }

    public async Task<long> GetAllProductsCount()
    {
        return await ProductRepository.SelectAllProductsCount();
    }
}

