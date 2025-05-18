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

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await MainContext.Products
            .AnyAsync(p => p.Name == name && !p.IsDeleted);

    }

    public async Task<long> InsertProductAsync(Product product)
    {
        MainContext.Products.Add(product);
        await MainContext.SaveChangesAsync();
        return product.ProductId;
    }

    public async Task<List<Product>> SelectAllProductsAsync(int skip, int take)
    {
        return await MainContext.Products
                   .Where(p => !p.IsDeleted)
                   .Skip(skip)
                   .Take(take)
                   .ToListAsync();
    }

    public async Task<long> SelectAllProductsCount()
    {
        return await MainContext.Products
            .Where(p => !p.IsDeleted)
            .CountAsync();
    }

    public async Task<Product?> SelectProductByIdAsync(long productId)
    {
        return await MainContext.Products
            .FirstOrDefaultAsync(p => p.ProductId == productId && !p.IsDeleted);
    }

    public async Task SoftDeleteProductAsync(long productId)
    {
        var product = await MainContext.Products
             .FirstOrDefaultAsync(p => p.ProductId == productId && !p.IsDeleted);
        if (product != null)
        {
            product.IsDeleted = true;
            await MainContext.SaveChangesAsync();
        }
    }

    public async Task UpdateProductAsync(Product product)
    {
        MainContext.Products.Update(product);
        await MainContext.SaveChangesAsync();
    }
}
