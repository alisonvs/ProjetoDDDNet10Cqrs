using ProjetoDDDNet10.Domain.Common;
using ProjetoDDDNet10.Domain.Events;
using ProjetoDDDNet10.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public string Phone { get; set; }

        public ICollection<Freight> Freights { get; set; } = new List<Freight>();
        protected Customer() { }

        public Customer(string name, string email, string phone)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetEmail(email);
            CreatedAt = DateTime.UtcNow;
            Phone = phone;
            AddDomainEvent(new CustomerCreatedEvent(Id));
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Name is required");

            Name = name;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new DomainException("Email is required");

            Email = email;
        }
        public void SetPhone(string phone)
        {
            if(string.IsNullOrWhiteSpace(phone))
                throw new DomainException("Phone is required");
            Phone = phone;
        }
    }
}
