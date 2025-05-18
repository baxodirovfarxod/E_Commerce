using E_Commerce.Dal.Entities;

namespace E_Commerce.Repository.Repositories.ProductRepository;

public interface IProductRepository
{
    Task<long> InsertProductAsync(Product product);
    Task<Product?> SelectProductByIdAsync(long productId);
    Task UpdateProductAsync(Product product);
    Task SoftDeleteProductAsync(long productId);
    Task<List<Product>> SelectAllProductsAsync(int skip, int take);
    Task<bool> ExistsByNameAsync(string name );
    Task<long> SelectAllProductsCount();
}
