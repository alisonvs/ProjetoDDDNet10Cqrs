using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }

        protected Customer() { }

        public Customer(string name, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            CreatedAt = DateTime.UtcNow;

            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new Exception("Name is required");

            if (string.IsNullOrWhiteSpace(Email))
                throw new Exception("Email is required");
        }
    }
}
