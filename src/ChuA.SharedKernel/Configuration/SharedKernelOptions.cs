using System.ComponentModel.DataAnnotations;
using ChuA.SharedKernel.Constants;

namespace ChuA.SharedKernel.Configuration;

/// <summary>
/// Represents strongly typed configuration for the shared kernel.
/// </summary>
public sealed class SharedKernelOptions
{
    /// <summary>
    /// Gets or sets the application name used in diagnostics and cross-cutting metadata.
    /// </summary>
    [Required]
    [MinLength(1)]
    public string ApplicationName { get; set; } = SharedKernelDefaults.ApplicationName;

    /// <summary>
    /// Gets or sets the environment name used when host environment details are unavailable.
    /// </summary>
    [Required]
    [MinLength(1)]
    public string EnvironmentName { get; set; } = SharedKernelDefaults.EnvironmentName;

    /// <summary>
    /// Gets or sets the inbound or outbound header name used for correlation identifiers.
    /// </summary>
    [Required]
    [MinLength(1)]
    public string CorrelationHeaderName { get; set; } = SharedKernelDefaults.CorrelationHeaderName;

    /// <summary>
    /// Gets or sets a value indicating whether detailed errors may be exposed to callers.
    /// </summary>
    public bool EnableDetailedErrors { get; set; }

    /// <summary>
    /// Gets or sets the default number of items returned by paged queries.
    /// </summary>
    [Range(1, SharedKernelDefaults.MaxPageSize)]
    public int DefaultPageSize { get; set; } = SharedKernelDefaults.DefaultPageSize;

    /// <summary>
    /// Gets or sets the maximum number of items returned by paged queries.
    /// </summary>
    [Range(1, 10_000)]
    public int MaxPageSize { get; set; } = SharedKernelDefaults.MaxPageSize;

    /// <summary>
    /// Gets or sets the clock kind used by the default system clock.
    /// </summary>
    public SharedKernelClockKind ClockKind { get; set; } = SharedKernelClockKind.Utc;
}
