using E_Commerce.Dal.Entities;

namespace E_Commerce.Repository.Repositories;

public interface ICustomerRepository
{
    Task<long> InsertCustomerAsync(Customer customer);
    Task<Customer> SelectCustomerByIdAsync(long customerId);
    Task DeleteCustomerByIdAsync(long customerId);
}
