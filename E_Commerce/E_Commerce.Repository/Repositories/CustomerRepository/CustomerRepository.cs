using E_Commerce.Dal;
using E_Commerce.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repository.Repositories.CustomerRepository;

public class CustomerRepository : ICustomerRepository
{
    private readonly MainContext Maincontext;

    public CustomerRepository(MainContext maincontext)
    {
        Maincontext = maincontext;
    }

    public async Task DeleteCustomerByIdAsync(long customerId)
    {
        var customer = await Maincontext.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
        if (customer != null)
        {
            Maincontext.Customers.Remove(customer);
            await Maincontext.SaveChangesAsync();
        }
    }

    public async Task<long> InsertCustomerAsync(Customer customer)
    {
        await Maincontext.Customers.AddAsync(customer);
        await Maincontext.SaveChangesAsync();
        return customer.CustomerId;
    }

    public async Task<List<Customer>> SelectAllCustomersAsync(int skip, int take)
    {
        return await Maincontext.Customers
           .Skip(skip)
           .Take(take)
           .ToListAsync();
    }

    public async Task<Customer?> SelectCustomerByEmailAsync(string email)
    {
        return await Maincontext.Customers.FirstOrDefaultAsync(c => c.Email == email);
    }

    public async Task<Customer?> SelectCustomerByIdAsync(long customerId)
    {
        return await Maincontext.Customers
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);
    }
}

