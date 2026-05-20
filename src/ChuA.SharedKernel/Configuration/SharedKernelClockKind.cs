// Copyright (c) 2026 Alvin Wilsen Chan Chua
// GitHub: chuaalvw-y
// Licensed under the Alvin Wilsen Chan Chua Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

namespace ChuA.SharedKernel.Configuration;

/// <summary>
/// Defines the time zone behavior used by the default clock.
/// </summary>
public enum SharedKernelClockKind
{
    /// <summary>
    /// Use UTC timestamps.
    /// </summary>
    Utc = 0,

    /// <summary>
    /// Use local machine timestamps.
    /// </summary>
    Local = 1
}
