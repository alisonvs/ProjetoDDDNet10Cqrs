using MediatR;
using Microsoft.Extensions.Logging;
using ProjetoDDDNet10.Application.Queries;
using ProjetoDDDNet10.Domain.Entities;
using ProjetoDDDNet10.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Application.Handlers
{
    public class GetCustomerByIdHandler
      : IRequestHandler<GetCustomerByIdQuery, Customer?>
    {
        private readonly ICustomerRepository _repository;
        private readonly ILogger<GetCustomerByIdHandler> _logger;

        public GetCustomerByIdHandler(ICustomerRepository repository,
                                      ILogger<GetCustomerByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Customer?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Searching customer {Id}", request.Id);

            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
