using MediatR;
using ProjetoDDDNet10.Application.Common;
using ProjetoDDDNet10.Application.DTO;
using ProjetoDDDNet10.Application.Queries;
using ProjetoDDDNet10.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Application.Handlers
{
    public class GetAllCustomersHandler
     : IRequestHandler<GetAllCustomersQuery, Result<List<CustomerDto>>>
    {
        private readonly ICustomerRepository _repository;

        public GetAllCustomersHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<CustomerDto>>> Handle(
            GetAllCustomersQuery request,
            CancellationToken cancellationToken)
        {
            var customers = await _repository.GetAllAsync();

            var dto = customers
                .Select(c => new CustomerDto(c.Id, c.Name, c.Email))
                .ToList();

            return Result<List<CustomerDto>>.Ok(dto);
        }
    }
}
