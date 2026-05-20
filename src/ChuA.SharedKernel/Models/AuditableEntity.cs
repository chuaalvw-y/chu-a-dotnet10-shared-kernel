// Copyright (c) 2026 Alvin Wilsen Chan Chua
// GitHub: chuaalvw-y
// Licensed under the Alvin Wilsen Chan Chua Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

namespace ChuA.SharedKernel.Models;

/// <summary>
/// Provides auditable fields for entities.
/// </summary>
/// <typeparam name="TId">The identifier type.</typeparam>
public abstract class AuditableEntity<TId>(TId id) : Entity<TId>(id)
    where TId : notnull
{
    /// <summary>
    /// Gets or sets the time at which the entity was created.
    /// </summary>
    public DateTimeOffset CreatedOn { get; protected set; }

    /// <summary>
    /// Gets or sets the principal that created the entity.
    /// </summary>
    public string? CreatedBy { get; protected set; }

    /// <summary>
    /// Gets or sets the time at which the entity was last modified.
    /// </summary>
    public DateTimeOffset? ModifiedOn { get; protected set; }

    /// <summary>
    /// Gets or sets the principal that last modified the entity.
    /// </summary>
    public string? ModifiedBy { get; protected set; }
}
