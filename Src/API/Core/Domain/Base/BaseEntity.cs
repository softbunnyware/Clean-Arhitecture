using Domain.Abstractions;

namespace Domain.Base;

public abstract class BaseEntity : BaseEntity<Guid>
{
}

public abstract class BaseEntity<TId> : IEntity<TId>
{
    public TId Id { get; protected set; } = default!;
}
