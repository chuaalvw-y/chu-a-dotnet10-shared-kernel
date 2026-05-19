namespace ChuA.SharedKernel.Abstractions;

/// <summary>
/// Provides correlation identifiers for logs, traces, messages, and requests.
/// </summary>
public interface ICorrelationIdProvider
{
    /// <summary>
    /// Gets the current correlation identifier.
    /// </summary>
    string CorrelationId { get; }
}
