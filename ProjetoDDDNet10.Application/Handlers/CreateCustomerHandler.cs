using MediatR;
using Microsoft.Extensions.Logging;
using ProjetoDDDNet10.Application.Commands;
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
    public class CreateCustomerCommandHandler
     : IRequestHandler<CreateCustomerCommand, Result<Guid>>
    {
        private readonly ICustomerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCustomerCommandHandler(ICustomerRepository repository, IUnitOfWork unitOfWorkv)
        {
            _repository = repository;
            _unitOfWork = unitOfWorkv;
        }

        public async Task<Result<Guid>> Handle(
            CreateCustomerCommand request,
            CancellationToken cancellationToken)
        {
            // 🔥 VALIDAÇÃO AQUI
            if (string.IsNullOrWhiteSpace(request.Name))
                return Result<Guid>.Failure("Nome é obrigatório.");

            if (string.IsNullOrWhiteSpace(request.Email))
                return Result<Guid>.Failure("Email é obrigatório.");
            
            var exists = await _repository.ExistsByEmailAsync(request.Email);

            if (exists)
                return Result<Guid>.Conflict("Já existe um cliente com este email.",409);

            var customer = new Customer(request.Name, request.Email);

            await _repository.AddAsync(customer);
            await _unitOfWork.CommitAsync();
            return Result<Guid>.Success(customer.Id);
        }
    }


}
