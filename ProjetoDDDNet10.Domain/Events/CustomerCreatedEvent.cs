using ProjetoDDDNet10.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Domain.Events
{
    public record CustomerCreatedEvent(Guid CustomerId) : IDomainEvent;
}
