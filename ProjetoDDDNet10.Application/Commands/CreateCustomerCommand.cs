using MediatR;
using ProjetoDDDNet10.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Application.Commands
{
    public record CreateCustomerCommand(string Name, string Email)
    : IRequest<Result<Guid>>;
}
