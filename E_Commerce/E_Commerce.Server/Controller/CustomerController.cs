using E_Commerce.Bll.Dtos.CustomerDTOs;
using E_Commerce.Bll.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Server.Controller
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService CustomerService;

        public CustomerController(ICustomerService customerService)
        {
            CustomerService = customerService;
        }

        [HttpPost("create")]
        public async Task<long> CreateCustomerAsync(CustomerCreateDto customerCreateDto)
        {
            return await CustomerService.CreateCustomerAsync(customerCreateDto);
        }

        [HttpGet("getById")]
        public async Task<CustomerGetDto> GetCustomerByIdAsync(long customerId)
        {
            return await CustomerService.GetCustomerByIdAsync(customerId);
        }

        [HttpGet("getAll")]
        public async Task<List<CustomerGetDto>> GetAllCustomersAsync(int skip, int take)
        {
            return await CustomerService.GetAllCustomersAsync(skip, take);
        }

        [HttpDelete("delete")]
        public async Task DeleteCustomerAsync(long customerId)
        {
            await CustomerService.DeleteCustomerAsync(customerId);
        }
    }
}
