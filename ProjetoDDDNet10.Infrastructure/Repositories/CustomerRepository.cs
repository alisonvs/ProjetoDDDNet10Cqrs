using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProjetoDDDNet10.Domain.Entities;
using ProjetoDDDNet10.Domain.Interfaces;
using ProjetoDDDNet10.Infrastructure.Data;
using System;


namespace ProjetoDDDNet10.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {            
            await _context.Customers.AddAsync(customer);
          
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Customer?> GetByIdAsync(Guid id)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(x => x.Id == id);
        }      
        public async Task<List<Customer>> GetAllAsync()
        {
           
            return await _context.Customers
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
        public async Task<List<Customer>> SearchByNameAsync(string name)
        {
            return await _context.Customers
                .AsNoTracking()
                .Where(x => x.Name.Contains(name))
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Customers.AsNoTracking().Where(_context => _context.Email.Contains(email)).AnyAsync();
        }
    }
}
