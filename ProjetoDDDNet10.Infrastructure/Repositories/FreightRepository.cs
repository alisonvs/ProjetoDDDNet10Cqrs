using Microsoft.EntityFrameworkCore;
using ProjetoDDDNet10.Domain.Entities;
using ProjetoDDDNet10.Domain.Interfaces;
using ProjetoDDDNet10.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Infrastructure.Repositories
{
    public class FreightRepository : IFreightRepository
    {
        private readonly TransportDbContext _context;
        public FreightRepository(TransportDbContext context)
        {
            _context = context;                 
        }

        public async Task AddAsync(Freight customer)
        {
           await _context.Freights.AddAsync(customer);          
        }

        public async Task<List<Freight>> GetAllAsync()
        {
            return await _context.Freights.ToListAsync();
        }

        public async Task<Freight?> GetByIdAsync(Guid id)
        {
           return await _context.Freights.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Freight>> SearchByNameAsync(string name)
        {
            return _context.Freights.Where(f => f.Origin.Contains(name) || f.Destination.Contains(name)).ToList();
        }
    }
}
