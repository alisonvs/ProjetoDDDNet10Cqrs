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

        protected Customer() { }

        public Customer(string name, string email)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetEmail(email);
            CreatedAt = DateTime.UtcNow;
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
    }
}
