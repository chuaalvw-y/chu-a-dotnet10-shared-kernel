namespace ChuA.SharedKernel.Models;

/// <summary>
/// Represents the outcome of an operation.
/// </summary>
public class Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result" /> class.
    /// </summary>
    /// <param name="isSuccess">A value indicating whether the result is successful.</param>
    /// <param name="errors">The errors associated with a failed result.</param>
    protected Result(bool isSuccess, IReadOnlyCollection<Error> errors)
    {
        if (isSuccess && errors.Count > 0)
        {
            throw new ArgumentException("Successful results cannot contain errors.", nameof(errors));
        }

        if (!isSuccess && errors.Count == 0)
        {
            throw new ArgumentException("Failed results must contain at least one error.", nameof(errors));
        }

        IsSuccess = isSuccess;
        Errors = errors;
    }

    /// <summary>
    /// Gets a value indicating whether the result succeeded.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets a value indicating whether the result failed.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Gets the errors associated with a failed result.
    /// </summary>
    public IReadOnlyCollection<Error> Errors { get; }

    /// <summary>
    /// Creates a successful result.
    /// </summary>
    /// <returns>A successful result.</returns>
    public static Result Success() => new(true, Array.Empty<Error>());

    /// <summary>
    /// Creates a failed result.
    /// </summary>
    /// <param name="error">The error that caused the failure.</param>
    /// <returns>A failed result.</returns>
    public static Result Failure(Error error) => Failure([error]);

    /// <summary>
    /// Creates a failed result.
    /// </summary>
    /// <param name="errors">The errors that caused the failure.</param>
    /// <returns>A failed result.</returns>
    public static Result Failure(IEnumerable<Error> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        return new Result(false, errors.Where(error => error != Error.None).ToArray());
    }
}
