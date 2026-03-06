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
            RuleFor(x => x.Phone)
             .NotEmpty().WithMessage("O telefone é obrigatório.")
             .Matches(@"^\(?\d{2}\)?\s?(?:9\d{4}|\d{4})-?\d{4}$")
             .WithMessage("Telefone inválido. Use o formato (XX) XXXXX-XXXX ou (XX) XXXX-XXXX.");
        }
    }
}
