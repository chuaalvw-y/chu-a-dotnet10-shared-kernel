// Copyright (c) 2026 Alvin Wilsen Chan Chua
// GitHub: chuaalvw-y
// Licensed under the Alvin Wilsen Chan Chua Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

using ChuA.SharedKernel.Abstractions;

namespace ChuA.SharedKernel.Providers;

/// <summary>
/// Provides an unauthenticated user context for background processes and tests.
/// </summary>
public sealed class NullCurrentUserProvider : ICurrentUserProvider
{
    /// <inheritdoc />
    public string? UserId => null;

    /// <inheritdoc />
    public string? UserName => null;

    /// <inheritdoc />
    public bool IsAuthenticated => false;
}
