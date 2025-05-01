using E_Commerce.Bll.Dtos.OrderDTOs;
using FluentValidation;

namespace E_Commerce.Bll.Validators.OrderValidator;

public class OrderCreateDtoValidator : AbstractValidator<OrderCreateDto>
{
    public OrderCreateDtoValidator()
    {
        RuleFor(x => x.CustomerId)
            .GreaterThan(0)
            .WithMessage("CustomerId must be greater than 0.");

        RuleFor(x => x.Discount)
            .NotEmpty()
            .WithMessage("Discount is required.")
            .GreaterThan(0)
            .WithMessage("Discount must be greater than 0.")
            .LessThan(100)
            .WithMessage("Discount must be less than 100.");

        RuleFor(x => x.DiscountPercentage)
            .InclusiveBetween((byte)0, (byte)100)
            .WithMessage("DiscountPercentage must be between 0 and 100.");
    }
}

