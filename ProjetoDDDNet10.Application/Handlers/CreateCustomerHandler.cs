using MediatR;
using Microsoft.Extensions.Logging;
using ProjetoDDDNet10.Application.Commands;
using ProjetoDDDNet10.Application.Common;
using ProjetoDDDNet10.Domain.Entities;
using ProjetoDDDNet10.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace ProjetoDDDNet10.Application.Handlers
{
    public class CreateCustomerHandler
    : IRequestHandler<CreateCustomerCommand, Result<Guid>>
    {
        private readonly ICustomerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerHandler(
            ICustomerRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(
            CreateCustomerCommand request,
            CancellationToken cancellationToken)
        {
            var customer = new Customer(request.Name, request.Email);

            await _repository.AddAsync(customer);
            await _unitOfWork.CommitAsync();

            return Result<Guid>.Ok(customer.Id);
        }
    }
}