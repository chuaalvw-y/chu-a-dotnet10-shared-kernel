namespace ChuA.SharedKernel.Abstractions;

/// <summary>
/// Represents an entity with a stable identifier.
/// </summary>
/// <typeparam name="TId">The identifier type.</typeparam>
public interface IEntity<out TId>
{
    /// <summary>
    /// Gets the entity identifier.
    /// </summary>
    TId Id { get; }
}
