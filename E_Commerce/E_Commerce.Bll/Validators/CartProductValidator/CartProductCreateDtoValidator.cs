using E_Commerce.Bll.Dtos.CartProductDTOs;
using FluentValidation;

namespace E_Commerce.Bll.Validators.CartProductValidator;

public class CartProductCreateDtoValidator : AbstractValidator<CartProductCreateDto>
{
    public CartProductCreateDtoValidator()
    {
        RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than 0.");

        RuleFor(x => x.CartId)
               .GreaterThan(0)
               .WithMessage("CartId must be greater than 0.");

        RuleFor(x => x.ProductId)
                .GreaterThan(0)
                .WithMessage("ProductId must be greater than 0.");
    }
}

