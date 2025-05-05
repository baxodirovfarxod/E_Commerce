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
                                .Include(c => c.Cards)
                                .Include(c => c.Orders)
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
            .Include(c => c.Cards)
            .Include(c => c.Orders)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);
    }

    public async Task<Customer?> SelectCustomerByIdAsync(long customerId, bool withCart = false, bool withCartProduct = false, bool withProduct = false)
    {
        var query = Maincontext.Customers.AsQueryable();

        if (withCart && withCartProduct && withProduct)
        {
            query = query.Include(c => c.Cart)
                         .ThenInclude(c => c.CartProducts)
                         .ThenInclude(cp => cp.Product);
        }
        else if (withCart && withCartProduct)
        {
            query = query.Include(c => c.Cart)
                         .ThenInclude(c => c.CartProducts);
        }
        else if (withCart)
        {
            query = query.Include(c => c.Cart);
        }

        return await query.FirstOrDefaultAsync(c => c.CustomerId == customerId);
    }
}

