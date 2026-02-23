using System;
using System.Collections.Generic;
using System.Text;

using MediatR;
using Microsoft.Extensions.Logging;
using ProjetoDDDNet10.Application.Commands;
using ProjetoDDDNet10.Domain.Entities;
using ProjetoDDDNet10.Domain.Interfaces;


namespace ProjetoDDDNet10.Application.Handlers
{


    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _repository;
        private readonly ILogger<CreateCustomerHandler> _logger;

        public CreateCustomerHandler(ICustomerRepository repository,
                                     ILogger<CreateCustomerHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating customer {Name}", request.Name);

            var customer = new Customer(request.Name, request.Email);

            await _repository.AddAsync(customer);

            _logger.LogInformation("Customer created with ID {Id}", customer.Id);

            return customer.Id;
        }
    }
}
