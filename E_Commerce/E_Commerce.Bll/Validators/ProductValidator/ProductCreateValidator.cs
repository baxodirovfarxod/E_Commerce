using E_Commerce.Bll.Dtos.ProductDTOs;
using FluentValidation;

namespace E_Commerce.Bll.Validators.ProductValidator;

public class ProductCreateValidator
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {

        public ProductCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Stock quantity must be 0 or more.");

            RuleFor(x => x.ImageLink)
                .MaximumLength(300).WithMessage("Image link must not exceed 300 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.ImageLink));

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Image link must not exceed 500 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.ImageLink));
        }
    }
}
