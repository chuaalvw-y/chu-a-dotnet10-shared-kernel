// Copyright (c) 2026 Alvin Wilsen Chan Chua
// GitHub: chuaalvw-y
// Licensed under the Alvin Wilsen Chan Chua Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

namespace ChuA.SharedKernel.Constants;

/// <summary>
/// Provides default values used by the shared kernel.
/// </summary>
public static class SharedKernelDefaults
{
    /// <summary>
    /// The default configuration section name for shared kernel options.
    /// </summary>
    public const string ConfigurationSectionName = "ChuA:SharedKernel";

    /// <summary>
    /// The default header name used to pass correlation identifiers.
    /// </summary>
    public const string CorrelationHeaderName = "X-Correlation-ID";

    /// <summary>
    /// The fallback application name used when configuration does not provide one.
    /// </summary>
    public const string ApplicationName = "ChuA.Application";

    /// <summary>
    /// The default environment name used by non-hosted unit tests and local tools.
    /// </summary>
    public const string EnvironmentName = "Production";

    /// <summary>
    /// The default page size for paged queries.
    /// </summary>
    public const int DefaultPageSize = 25;

    /// <summary>
    /// The maximum allowed page size for paged queries.
    /// </summary>
    public const int MaxPageSize = 250;
}
