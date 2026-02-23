using MediatR;
using ProjetoDDDNet10.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace ProjetoDDDNet10.Application.Queries
{   
        public record GetCustomerByIdQuery(Guid Id) : IRequest<Customer?>;    
}
