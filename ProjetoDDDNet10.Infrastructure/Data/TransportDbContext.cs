using Microsoft.EntityFrameworkCore;
using ProjetoDDDNet10.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Infrastructure.Data
{
    public class TransportDbContext : DbContext
    {
        public TransportDbContext(DbContextOptions<TransportDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Freight> Freights => Set<Freight>();
        public DbSet<Partner> Partners => Set<Partner>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Freight>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Origin)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(x => x.Destination)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(x => x.ChargedAmount)
                    .HasColumnType("numeric(12,2)");

                entity.Property(x => x.CostAmount)
                    .HasColumnType("numeric(12,2)");

                entity.HasOne(x => x.Customer)
                    .WithMany(c => c.Freights)
                    .HasForeignKey(x => x.CustomerId);
            });
        }
    }


}
