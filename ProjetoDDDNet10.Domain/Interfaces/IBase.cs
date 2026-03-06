using ProjetoDDDNet10.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Domain.Interfaces
{
    public interface IBase<T> where T : class
    {
        Task AddAsync(T customer);
        Task<T?> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> SearchByNameAsync(string name);
        Task SaveChangesAsync();
    }
}
