namespace ChuA.SharedKernel.Models.Exceptions;

/// <summary>
/// Represents the base exception for shared kernel failures.
/// </summary>
public class SharedKernelException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SharedKernelException" /> class.
    /// </summary>
    public SharedKernelException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SharedKernelException" /> class.
    /// </summary>
    /// <param name="message">The exception message.</param>
    public SharedKernelException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SharedKernelException" /> class.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="innerException">The inner exception.</param>
    public SharedKernelException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
