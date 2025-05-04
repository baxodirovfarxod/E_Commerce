using AutoMapper;
using E_Commerce.Bll.Dtos.CustomerDTOs;
using E_Commerce.Dal.Entities;
using E_Commerce.Repository.Repositories.CustomerRepository;
using FluentValidation;

namespace E_Commerce.Bll.Services.CustomerService;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository CustomerRepository;
    private readonly IMapper Mapper;
    private readonly IValidator<CustomerCreateDto> CustomerCreateDtoValidator;
    private readonly IValidator<CustomerUpdateDto> CustomerUpdateDtoValidator;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper, IValidator<CustomerCreateDto> customerCreateDtoValidator, IValidator<CustomerUpdateDto> customerUpdateDtoValidator)
    {
        CustomerRepository = customerRepository;
        Mapper = mapper;
        CustomerCreateDtoValidator = customerCreateDtoValidator;
        CustomerUpdateDtoValidator = customerUpdateDtoValidator;
    }

    public async Task<long> CreateCustomerAsync(CustomerCreateDto customerCreateDto)
    {
        ArgumentNullException.ThrowIfNull(customerCreateDto);
        var validationResult = await CustomerCreateDtoValidator.ValidateAsync(customerCreateDto);
        if (!validationResult.IsValid)
        {
            var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException($"Validation failed: {errors}");
        }

        return await CustomerRepository.InsertCustomerAsync(Mapper.Map<Customer>(customerCreateDto));
    }

    public async Task DeleteCustomerAsync(long customerId)
    {
        var customer = await CustomerRepository.SelectCustomerByIdAsync(customerId);

        if (customer == null)
        {
            throw new Exception($"Customer with {customerId} not found");
        }

        await CustomerRepository.DeleteCustomerByIdAsync(customerId);
    }

    public async Task<List<CustomerGetDto>> GetAllCustomersAsync(int skip, int take)
    {
        var customers = await CustomerRepository.SelectAllCustomersAsync(skip, take);

        return customers.Select(c => Mapper.Map<CustomerGetDto>(c)).ToList();
    }

    public async Task<CustomerGetDto> GetCustomerByIdAsync(long customerId)
    {
        var customer = await CustomerRepository.SelectCustomerByIdAsync(customerId);

        if (customer == null)
        {
            throw new Exception($"Customer with {customerId} not found");
        }

        return Mapper.Map<CustomerGetDto>(customer);
    }
}
