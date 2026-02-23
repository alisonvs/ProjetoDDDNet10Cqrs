using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace ProjetoDDDNet10.Application.Commands
{    
    public record CreateCustomerCommand(string Name, string Email) : IRequest<Guid>;
}
