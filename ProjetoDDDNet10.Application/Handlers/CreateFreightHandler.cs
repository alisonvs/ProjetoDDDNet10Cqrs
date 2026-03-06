using MediatR;
using ProjetoDDDNet10.Application.Commands;
using ProjetoDDDNet10.Application.Common;
using ProjetoDDDNet10.Domain.Entities;
using ProjetoDDDNet10.Domain.Enums;
using ProjetoDDDNet10.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Application.Handlers
{
    public class CreateFreightCommandHandler
        : IRequestHandler<CreateFreightCommand, Result<Guid>>
    {
        private readonly IFreightRepository _repository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateFreightCommandHandler(IFreightRepository repository, ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateFreightCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Origin) || string.IsNullOrWhiteSpace(request.Destination))
            {
                return await Task.FromResult(Result<Guid>.Failure("Origin and Destination are required.", 400));
            }

            if (request.ChargedAmount <= 0)
            {
                return await Task.FromResult(Result<Guid>.Failure("Charged Amount must be greater than zero.", 400));
            }

            if (request.CostAmount < 0)
            {
                return await Task.FromResult(Result<Guid>.Failure("Cost Amount cannot be negative.", 400));
            }
            if(request.CustomerId == Guid.Empty)
            {
                return await Task.FromResult(Result<Guid>.Failure("Customer ID is required.", 400));
            }
            if (request.CostAmount > request.ChargedAmount)
            {
                return await Task.FromResult(Result<Guid>.Failure("Cost Amount cannot exceed Charged Amount.", 400));
            }

            if (!Enum.IsDefined(typeof(VehicleType), request.VehicleType))
            {
                return await Task.FromResult(Result<Guid>.Failure("Invalid Vehicle Type.", 400));
            }

            if (request.FreightDate < DateTime.Today)
            {
                return await Task.FromResult(Result<Guid>.Failure("Freight Date cannot be in the past.", 400));
            }

            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);

            if (customer == null)
                return Result<Guid>.Failure("Customer not found.", 404);
            
            // If all validations pass, continue with creation
            var freight = new Freight(
                Guid.NewGuid(),
                request.CustomerId,
                customer,
                request.Origin,
                request.Destination,
                request.ChargedAmount,
                request.CostAmount,
                request.VehicleType,
                request.FreightStatus,
                request.FreightDate               
            );
                       
            await _repository.AddAsync(freight);
            await _unitOfWork.CommitAsync();
            return Result<Guid>.Success(freight.Id);


        }
    }

}
