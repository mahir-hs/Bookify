﻿namespace Bookify.Domain.Abstractions;
public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = [];
    protected Entity(Guid id) => Id = id;
    protected Entity()
    {

    }
    public Guid Id { get; init; }

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }
    public void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

}
