using Microsoft.EntityFrameworkCore;
using ProjetoDDDNet10.Domain.Entities;
using ProjetoDDDNet10.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;



namespace ProjetoDDDNet10.Infrastructure.Data
{

    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers => Set<Customer>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
    
}
