using E_Commerce.Bll.Dtos.CustomerDTOs;
using FluentValidation;

namespace E_Commerce.Bll.Validators.CustomerValidator;

public class CustomerUpdateDtoValidator : AbstractValidator<CustomerUpdateDto>
{
    public CustomerUpdateDtoValidator()
    {
        Include(new CustomerCreateDtoValidator());

        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage("CustomerId must be greater than 0.");
    }
}
