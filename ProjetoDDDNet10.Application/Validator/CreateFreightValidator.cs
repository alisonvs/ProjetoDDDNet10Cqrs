using FluentValidation;
using ProjetoDDDNet10.Application.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ProjetoDDDNet10.Application.Validator
{
    public class CreateFreightValidator: AbstractValidator<CreateFreightCommand>
    {
        public CreateFreightValidator()
        {
            RuleFor(x=>x.Origin).NotEmpty().WithMessage("A origem é obrigatória.");
            RuleFor(x => x.Destination).NotEmpty().WithMessage("O destino é obrigatório.");
            RuleFor(x => x.ChargedAmount).GreaterThan(0).WithMessage("O valor cobrado deve ser maior que zero.");
            RuleFor(x => x.CostAmount).GreaterThan(0).WithMessage("O custo deve ser maior que zero.");
            RuleFor(x => x.FreightDate).LessThanOrEqualTo(DateTime.Now).WithMessage("A data do frete não pode ser futura.");
            RuleFor(x => x.VehicleType).IsInEnum().WithMessage("Tipo de veículo inválido.");
            RuleFor(x => x.ChargedAmount).GreaterThanOrEqualTo(x => x.CostAmount).WithMessage("O valor cobrado deve ser maior ou igual ao custo.");
            RuleFor(x => x.Origin).MaximumLength(100).WithMessage("A origem deve ter no máximo 100 caracteres.");
            RuleFor(x => x.Destination).MaximumLength(100).WithMessage("O destino deve ter no máximo 100 caracteres.");

        }
       
    }
}
