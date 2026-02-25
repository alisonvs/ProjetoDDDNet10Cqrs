using ProjetoDDDNet10.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }

        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

        protected void AddDomainEvent(IDomainEvent eventItem)
            => _domainEvents.Add(eventItem);

        public void ClearDomainEvents()
            => _domainEvents.Clear();
    }
}
