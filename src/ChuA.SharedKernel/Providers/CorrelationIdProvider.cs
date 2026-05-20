// Copyright (c) 2026 Alvin Wilsen Chan Chua
// GitHub: chuaalvw-y
// Licensed under the Alvin Wilsen Chan Chua Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

using ChuA.SharedKernel.Abstractions;

namespace ChuA.SharedKernel.Providers;

/// <summary>
/// Provides a stable correlation identifier for the lifetime of the provider instance.
/// </summary>
public sealed class CorrelationIdProvider : ICorrelationIdProvider
{
    private readonly Lazy<string> _correlationId = new(() => Guid.NewGuid().ToString("N"));

    /// <inheritdoc />
    public string CorrelationId => _correlationId.Value;
}
