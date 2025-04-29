using E_Commerce.Dal;
using E_Commerce.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repository.Repositories.ProductRepository;

public class ProductRepository : IProductRepository
{
    private readonly MainContext MainContext;
    public ProductRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }
    public async Task<long> InsertProductAsync(Product product)
    {
        MainContext.Products.Add(product);
        await MainContext.SaveChangesAsync();
        return product.ProductId;
    }

    public async Task<Product?> SelectProductByIdAsync(long productId)
    {
        return await MainContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
    }

    public async Task UpdateProductAsync(Product product)
    {
        MainContext.Products.Update(product);
        await MainContext.SaveChangesAsync(); 
    }
}
