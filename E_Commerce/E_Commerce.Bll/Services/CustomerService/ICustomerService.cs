using E_Commerce.Bll.Dtos.CustomerDTOs;

namespace E_Commerce.Bll.Services.CustomerService;

public interface ICustomerService
{
    Task<long> CreateCustomerAsync(CustomerCreateDto customerCreateDto);
    Task<CustomerGetDto> GetCustomerByIdAsync(long customerId);
    Task<List<CustomerGetDto>> GetAllCustomersAsync(int skip, int take);
    Task DeleteCustomerAsync(long customerId);
}
