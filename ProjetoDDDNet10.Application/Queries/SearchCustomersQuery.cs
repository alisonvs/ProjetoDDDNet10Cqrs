using MediatR;
using ProjetoDDDNet10.Application.Common;
using ProjetoDDDNet10.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Application.Queries
{
    public record SearchCustomersQuery(string Name)
    : IRequest<Result<List<CustomerDto>>>;
}
