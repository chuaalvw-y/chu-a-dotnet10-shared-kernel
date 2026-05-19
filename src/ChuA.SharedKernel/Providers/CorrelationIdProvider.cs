using ChuA.SharedKernel.Abstractions;

namespace ChuA.SharedKernel.Providers;

/// <summary>
/// Provides a stable correlation identifier for the lifetime of the provider instance.
/// </summary>
public sealed class CorrelationIdProvider : ICorrelationIdProvider
{
    private readonly Lazy<string> _correlationId = new(() => Guid.NewGuid().ToString("N"));

    /// <inheritdoc />
    public string CorrelationId => _correlationId.Value;
}
