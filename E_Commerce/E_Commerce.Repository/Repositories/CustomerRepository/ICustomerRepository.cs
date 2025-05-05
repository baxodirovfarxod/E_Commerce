using E_Commerce.Dal.Entities;

namespace E_Commerce.Repository.Repositories.CustomerRepository;

public interface ICustomerRepository
{
    Task<long> InsertCustomerAsync(Customer customer);
    Task<Customer?> SelectCustomerByIdAsync(long customerId);
    Task DeleteCustomerByIdAsync(long customerId);
    Task<List<Customer>> SelectAllCustomersAsync(int skip, int take);
    Task<Customer?> SelectCustomerByEmailAsync(string email);
    Task<Customer?> SelectCustomerByIdAsync(long customerId, bool withCart = false, bool withCartProduct = false, bool withProduct = false);
}
