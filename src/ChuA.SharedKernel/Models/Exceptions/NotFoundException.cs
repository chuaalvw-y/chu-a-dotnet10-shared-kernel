// Copyright (c) 2026 Alvin Wilsen Chan Chua
// GitHub: chuaalvw-y
// Licensed under the Alvin Wilsen Chan Chua Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

namespace ChuA.SharedKernel.Models.Exceptions;

/// <summary>
/// Represents a failure to locate an expected resource.
/// </summary>
public sealed class NotFoundException : SharedKernelException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException" /> class.
    /// </summary>
    /// <param name="resourceName">The resource name.</param>
    /// <param name="key">The resource key.</param>
    public NotFoundException(string resourceName, object? key)
        : base($"{resourceName} with key '{key}' was not found.")
    {
        ResourceName = resourceName;
        Key = key;
    }

    /// <summary>
    /// Gets the resource name.
    /// </summary>
    public string ResourceName { get; }

    /// <summary>
    /// Gets the resource key.
    /// </summary>
    public object? Key { get; }
}
