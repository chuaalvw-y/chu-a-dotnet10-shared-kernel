using ChuA.SharedKernel.Abstractions;

namespace ChuA.SharedKernel.Providers;

/// <summary>
/// Provides an unauthenticated user context for background processes and tests.
/// </summary>
public sealed class NullCurrentUserProvider : ICurrentUserProvider
{
    /// <inheritdoc />
    public string? UserId => null;

    /// <inheritdoc />
    public string? UserName => null;

    /// <inheritdoc />
    public bool IsAuthenticated => false;
}
