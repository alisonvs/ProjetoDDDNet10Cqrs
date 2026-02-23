using FluentValidation;
using ProjetoDDDNet10.Application.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Application.Validator
{
    public class CreateCustomerValidator
      : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
