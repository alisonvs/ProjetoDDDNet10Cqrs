using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoDDDNet10.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Infrastructure.Dispatching
{
    public class DomainEventDispatcher
    {
        private readonly IMediator _mediator;

        public DomainEventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task DispatchEventsAsync(DbContext context)
        {
            var entities = context.ChangeTracker
                .Entries<BaseEntity>()
                .Where(x => x.Entity.DomainEvents.Any())
                .Select(x => x.Entity);

            foreach (var entity in entities)
            {
                var events = entity.DomainEvents;

                foreach (var domainEvent in events)
                    await _mediator.Publish(domainEvent);

                entity.ClearDomainEvents();
            }
        }
    }
}
