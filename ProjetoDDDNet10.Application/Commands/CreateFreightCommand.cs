using MediatR;
using ProjetoDDDNet10.Application.Common;
using ProjetoDDDNet10.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Application.Commands
{
    public record CreateFreightCommand(
    Guid Id,
    Guid CustomerId,    
    string Origin,
     string Destination,
    decimal ChargedAmount,
    decimal CostAmount,
    VehicleType VehicleType,
    FreightStatus FreightStatus,
    DateTime FreightDate
) : IRequest<Result<Guid>>;
}

