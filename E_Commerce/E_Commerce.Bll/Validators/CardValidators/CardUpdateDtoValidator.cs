using E_Commerce.Bll.Dtos.CardDTOs;
using FluentValidation;

namespace E_Commerce.Bll.Validators.CardValidators;

public class CardUpdateDtoValidator : AbstractValidator<CardUpdateDto>
{
    public CardUpdateDtoValidator()
    {
        RuleFor(x => x.CardId)
            .GreaterThan(0).WithMessage("Card ID must be greater than 0.");

        RuleFor(x => x.SelectedForPayment)
            .Equal(true)
            .WithMessage("SelectedForPayment must be true.");

    }
}

