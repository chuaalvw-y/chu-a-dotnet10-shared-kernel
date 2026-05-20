// Copyright (c) 2026 Alvin Wilsen Chan Chua
// GitHub: chuaalvw-y
// Licensed under the Alvin Wilsen Chan Chua Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

namespace ChuA.SharedKernel.Abstractions;

/// <summary>
/// Provides the current time through an injectable abstraction.
/// </summary>
public interface IClock
{
    /// <summary>
    /// Gets the current timestamp.
    /// </summary>
    DateTimeOffset Now { get; }
}
