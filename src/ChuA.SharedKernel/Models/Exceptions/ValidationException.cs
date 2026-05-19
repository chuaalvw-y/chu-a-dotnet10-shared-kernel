namespace ChuA.SharedKernel.Models.Exceptions;

/// <summary>
/// Represents one or more validation failures.
/// </summary>
public sealed class ValidationException : SharedKernelException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException" /> class.
    /// </summary>
    /// <param name="errors">The validation errors.</param>
    public ValidationException(IEnumerable<Error> errors)
        : base("One or more validation errors occurred.")
    {
        Errors = errors.ToArray();
    }

    /// <summary>
    /// Gets the validation errors.
    /// </summary>
    public IReadOnlyCollection<Error> Errors { get; }
}
