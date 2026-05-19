namespace ChuA.SharedKernel.Abstractions;

/// <summary>
/// Provides the current time through an injectable abstraction.
/// </summary>
public interface IClock
{
    /// <summary>
    /// Gets the current timestamp.
    /// </summary>
    DateTimeOffset Now { get; }
}
