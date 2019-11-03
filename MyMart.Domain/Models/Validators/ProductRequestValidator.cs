using FluentValidation;
using MyMart.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMart.Domain.Models.Validators
{
    public class ProductRequestValidator : AbstractValidator<ProductRequest>
    {
        public ProductRequestValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Product name is required");
            RuleFor(p => p.Price).NotEmpty().GreaterThanOrEqualTo(0M);
            RuleFor(p => p.RackId).NotEmpty().NotNull();
        }
    }
}
