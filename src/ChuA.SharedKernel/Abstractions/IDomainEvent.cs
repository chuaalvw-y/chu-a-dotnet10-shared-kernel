namespace ChuA.SharedKernel.Abstractions;

/// <summary>
/// Represents an event raised by a domain model.
/// </summary>
public interface IDomainEvent
{
    /// <summary>
    /// Gets the unique event identifier.
    /// </summary>
    Guid EventId { get; }

    /// <summary>
    /// Gets the time at which the event occurred.
    /// </summary>
    DateTimeOffset OccurredOn { get; }
}
