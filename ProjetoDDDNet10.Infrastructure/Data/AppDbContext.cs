using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProjetoDDDNet10.Domain.Entities;



namespace ProjetoDDDNet10.Infrastructure.Data
{

    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers => Set<Customer>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
