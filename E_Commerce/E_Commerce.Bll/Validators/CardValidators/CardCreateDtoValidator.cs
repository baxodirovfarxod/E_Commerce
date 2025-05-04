using E_Commerce.Bll.Dtos.CardDTOs;
using E_Commerce.Repository.Repositories.CustomerRepository;
using FluentValidation;

public class CardCreateDtoValidator : AbstractValidator<CardCreateDto>
{
    private readonly ICustomerRepository customerRepository;

    public CardCreateDtoValidator(ICustomerRepository customerRepository)
    {
        this.customerRepository = customerRepository;

        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage("Customer Id must be greater than 0.")
            .MustAsync(CustomerExistsAsync).WithMessage("Customer with this ID does not exist.");

        RuleFor(x => x.Number)
            .NotEmpty().WithMessage("Card number is required.")
            .Matches(@"^\d{16}$").WithMessage("Card number must be 16 digits.");

        RuleFor(x => x.HolderName)
            .NotEmpty().WithMessage("Holder name is required.");

        RuleFor(x => x.ExpirationMonth)
            .InclusiveBetween(1, 12)
            .WithMessage("Expiration month must be between 1 and 12.");

        RuleFor(x => x.ExpirationYear)
            .GreaterThan(DateTime.Now.Year)
            .WithMessage("Expiration year must be greater than the current year.");

        RuleFor(x => x.Cvv)
            .InclusiveBetween(100, 999)
            .WithMessage("CVV must be a 3-digit number.");
    }

    private async Task<bool> CustomerExistsAsync(long customerId, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.SelectCustomerByIdAsync(customerId);
        return customer != null;
    }
}
