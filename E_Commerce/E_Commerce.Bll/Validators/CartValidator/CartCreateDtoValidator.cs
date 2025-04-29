using E_Commerce.Bll.Dtos.CartDTOs;
using FluentValidation;

namespace E_Commerce.Bll.Validators.CartValidator;

public class CartCreateDtoValidator : AbstractValidator<CartCreateDto>
{
    public CartCreateDtoValidator()
    {
        RuleFor(x => x.CustomerId)
           .GreaterThan(0)
           .WithMessage("CustomerId must be greater than 0.");

        RuleFor(x => x.CreatedAt)
            .NotNull()
            .WithMessage("CreatedAt is required.");
    }
}
