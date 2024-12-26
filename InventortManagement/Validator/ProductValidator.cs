using FluentValidation;
using InventortManagement.Models;

namespace InventortManagement.Validator
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required & Should be greater than 0");
        }

    }
}