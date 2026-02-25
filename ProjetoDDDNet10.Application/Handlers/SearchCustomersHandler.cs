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
    public class SearchCustomersHandler
      : IRequestHandler<SearchCustomersQuery, Result<List<CustomerDto>>>
    {
        private readonly ICustomerRepository _repository;

        public SearchCustomersHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<CustomerDto>>> Handle(
            SearchCustomersQuery request,
            CancellationToken cancellationToken)
        {
            var customers = await _repository.SearchByNameAsync(request.Name);

            var dto = customers
                .Select(c => new CustomerDto(c.Id, c.Name, c.Email))
                .ToList();

            return Result<List<CustomerDto>>.Success(dto);
        }
    }
}
