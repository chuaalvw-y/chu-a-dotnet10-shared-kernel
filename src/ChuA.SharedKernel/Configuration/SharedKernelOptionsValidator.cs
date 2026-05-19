using Microsoft.Extensions.Options;

namespace ChuA.SharedKernel.Configuration;

/// <summary>
/// Validates semantic relationships between shared kernel option values.
/// </summary>
public sealed class SharedKernelOptionsValidator : IValidateOptions<SharedKernelOptions>
{
    /// <inheritdoc />
    public ValidateOptionsResult Validate(string? name, SharedKernelOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        if (options.DefaultPageSize > options.MaxPageSize)
        {
            return ValidateOptionsResult.Fail(
                $"{nameof(SharedKernelOptions.DefaultPageSize)} cannot be greater than {nameof(SharedKernelOptions.MaxPageSize)}.");
        }

        return ValidateOptionsResult.Success;
    }
}
