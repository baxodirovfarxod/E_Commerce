using E_Commerce.Bll.Dtos.PaymentDTOs;
using FluentValidation;

namespace E_Commerce.Bll.Validators.PaymentValidator;

public class PaymentCreateDtoValidator : AbstractValidator<PaymentCreateDto>
{
 public PaymentCreateDtoValidator()
    {
        RuleFor(x => x.PaymentMethod)
         .IsInEnum().WithMessage("Invalid payment method.");
        RuleFor(x => x.PaymentStatus)
         .IsInEnum().WithMessage("Invalid payment status.");
    }
}

