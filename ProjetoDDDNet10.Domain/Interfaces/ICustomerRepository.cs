using ProjetoDDDNet10.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task<Customer?> GetByIdAsync(Guid id);
        Task<List<Customer>> GetAllAsync();       
        Task<List<Customer>> SearchByNameAsync(string name);
        Task SaveChangesAsync();
    }

    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
