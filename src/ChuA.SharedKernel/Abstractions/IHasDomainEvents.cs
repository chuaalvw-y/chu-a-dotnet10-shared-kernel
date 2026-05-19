namespace ChuA.SharedKernel.Abstractions;

/// <summary>
/// Represents an object that can collect and clear domain events.
/// </summary>
public interface IHasDomainEvents
{
    /// <summary>
    /// Gets the domain events collected by the object.
    /// </summary>
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    /// <summary>
    /// Clears all collected domain events.
    /// </summary>
    void ClearDomainEvents();
}
