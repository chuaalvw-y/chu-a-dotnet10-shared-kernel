// Copyright (c) 2026 Alvin Wilsen Chan Chua
// GitHub: chuaalvw-y
// Licensed under the Alvin Wilsen Chan Chua Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

namespace ChuA.SharedKernel.Models.Exceptions;

/// <summary>
/// Represents a conflict with current application state.
/// </summary>
/// <param name="message">The conflict message.</param>
public sealed class ConflictException(string message) : SharedKernelException(message);
