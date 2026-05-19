namespace ChuA.SharedKernel.Abstractions;

/// <summary>
/// Provides information about the current user or workload identity.
/// </summary>
public interface ICurrentUserProvider
{
    /// <summary>
    /// Gets the current principal identifier, or <see langword="null" /> when anonymous or unavailable.
    /// </summary>
    string? UserId { get; }

    /// <summary>
    /// Gets the current principal display name, or <see langword="null" /> when unavailable.
    /// </summary>
    string? UserName { get; }

    /// <summary>
    /// Gets a value indicating whether the current principal is authenticated.
    /// </summary>
    bool IsAuthenticated { get; }
}
