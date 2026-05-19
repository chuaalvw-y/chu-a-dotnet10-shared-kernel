using ChuA.SharedKernel.Abstractions;
using ChuA.SharedKernel.Configuration;
using Microsoft.Extensions.Options;

namespace ChuA.SharedKernel.Services;

/// <summary>
/// Provides time based on shared kernel clock configuration.
/// </summary>
public sealed class SystemClock(IOptions<SharedKernelOptions> options) : IClock
{
    private readonly IOptions<SharedKernelOptions> _options = options;

    /// <inheritdoc />
    public DateTimeOffset Now =>
        _options.Value.ClockKind == SharedKernelClockKind.Local
            ? DateTimeOffset.Now
            : DateTimeOffset.UtcNow;
}
