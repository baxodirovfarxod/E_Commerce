using E_Commerce.Bll.Dtos.CustomerDTOs;
using E_Commerce.Repository.Repositories.CustomerRepository;
using FluentValidation;

namespace E_Commerce.Bll.Validators.CustomerValidator;

public class CustomerUpdateDtoValidator : AbstractValidator<CustomerUpdateDto>
{
    private readonly ICustomerRepository CustomerRepository;
    public CustomerUpdateDtoValidator(ICustomerRepository customerRepository)
    {
        CustomerRepository = customerRepository;

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name must be at most 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name must be at most 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.")
            .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("Email format is invalid.")
            .MustAsync(GetCustomerByEmailAsync).WithMessage("Email already exists.");

        RuleFor(x => x.PhoneNumber)
           .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+?\d{9,15}$").WithMessage("Invalid phone number format.");

        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage("CustomerId must be greater than 0.");
        CustomerRepository = customerRepository;
    }

    private async Task<bool> GetCustomerByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var exist = await CustomerRepository.SelectCustomerByEmailAsync(email);

        if (exist != null)
        {
            return false;
        }

        return true;
    }
}
