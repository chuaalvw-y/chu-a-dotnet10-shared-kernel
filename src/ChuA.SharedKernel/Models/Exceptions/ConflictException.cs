namespace ChuA.SharedKernel.Models.Exceptions;

/// <summary>
/// Represents a conflict with current application state.
/// </summary>
/// <param name="message">The conflict message.</param>
public sealed class ConflictException(string message) : SharedKernelException(message);
