using MediatR;
using Microsoft.Extensions.Logging;
using ProjetoDDDNet10.Application.Common;
using ProjetoDDDNet10.Application.DTO;
using ProjetoDDDNet10.Application.Queries;
using ProjetoDDDNet10.Domain.Entities;
using ProjetoDDDNet10.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Application.Handlers
{
    public class GetCustomerByIdHandler
    : IRequestHandler<GetCustomerByIdQuery, Result<CustomerDto>>
    {
        private readonly ICustomerRepository _repository;

        public GetCustomerByIdHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<CustomerDto>> Handle(
            GetCustomerByIdQuery request,
            CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.Id);

            if (customer is null)
                return Result<CustomerDto>.Fail("Customer not found");

            var dto = new CustomerDto(
                customer.Id,
                customer.Name,
                customer.Email);

            return Result<CustomerDto>.Ok(dto);
        }
    }
}
