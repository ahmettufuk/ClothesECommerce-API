using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Email).NotEmpty().NotNull().EmailAddress().MinimumLength(5);
            RuleFor(p => p.FirstName).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(p=>p.LastName).NotEmpty().NotNull().MinimumLength(1);
        }
    }
}
