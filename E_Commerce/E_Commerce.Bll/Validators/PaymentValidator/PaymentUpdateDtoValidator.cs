using E_Commerce.Bll.Dtos.PaymentDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Bll.Validators.PaymentValidator;

public class PaymentUpdateDtoValidator : AbstractValidator<PaymentUpdateDto>
{
    public PaymentUpdateDtoValidator()
    {
        RuleFor(x => x.PaymentId)
            .NotEmpty().WithMessage("Payment ID is required.")
            .GreaterThan(0).WithMessage("Payment ID must be greater than 0.");
        RuleFor(x => x.PaymentMethod)
            .IsInEnum().WithMessage("Invalid payment method.");
        RuleFor(x => x.PaymentStatus)
            .IsInEnum().WithMessage("Invalid payment status.");
    }
}

