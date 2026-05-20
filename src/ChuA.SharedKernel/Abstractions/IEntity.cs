// Copyright (c) 2026 Alvin Wilsen Chan Chua
// GitHub: chuaalvw-y
// Licensed under the Alvin Wilsen Chan Chua Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

namespace ChuA.SharedKernel.Abstractions;

/// <summary>
/// Represents an entity with a stable identifier.
/// </summary>
/// <typeparam name="TId">The identifier type.</typeparam>
public interface IEntity<out TId>
{
    /// <summary>
    /// Gets the entity identifier.
    /// </summary>
    TId Id { get; }
}
