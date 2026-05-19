using ChuA.SharedKernel.Abstractions;

namespace ChuA.SharedKernel.Models;

/// <summary>
/// Provides a base implementation for domain events.
/// </summary>
public abstract record DomainEvent : IDomainEvent
{
    /// <inheritdoc />
    public Guid EventId { get; init; } = Guid.NewGuid();

    /// <inheritdoc />
    public DateTimeOffset OccurredOn { get; init; } = DateTimeOffset.UtcNow;
}
