using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidator;
using FluentValidator.Validation;
using FluentValidation;

namespace BindingForm
{
    class CustomerContract : AbstractValidator<Osoba>
    {
        public CustomerContract()
        {
                RuleFor(customer => customer.FirstName).NotEmpty().WithMessage("Please specify a first name");
                RuleFor(customer => customer.LastName).NotEmpty().WithMessage("Please specify a last name");
        }
    }
}
