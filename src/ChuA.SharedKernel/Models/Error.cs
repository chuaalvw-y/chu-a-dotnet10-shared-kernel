namespace ChuA.SharedKernel.Models;

/// <summary>
/// Describes a structured application error.
/// </summary>
/// <param name="Code">A stable machine-readable error code.</param>
/// <param name="Message">A human-readable error message.</param>
/// <param name="Target">An optional field, parameter, or resource name associated with the error.</param>
public sealed record Error(string Code, string Message, string? Target = null)
{
    /// <summary>
    /// Represents the absence of an error.
    /// </summary>
    public static readonly Error None = new("None", string.Empty);

    /// <summary>
    /// Creates an error from an exception without exposing stack traces or implementation details.
    /// </summary>
    /// <param name="exception">The exception to map.</param>
    /// <param name="code">The stable error code to use.</param>
    /// <returns>A safe structured error.</returns>
    public static Error FromException(Exception exception, string code = "Unhandled") =>
        new(code, exception.Message);
}
