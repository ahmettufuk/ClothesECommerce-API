using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(p => p.UnitInStock).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(p=>p.UnitPrice).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
