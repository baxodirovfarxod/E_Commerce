using E_Commerce.Bll.Dtos.ProductDTOs;
using FluentValidation;

namespace E_Commerce.Bll.Validators.ProductValidator;

public class ProductUpdateValidator : AbstractValidator<ProductUpdateDto>
{
    public ProductUpdateValidator()
    {
        //Include(new ProductCreateValidator());

        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
    }
}


