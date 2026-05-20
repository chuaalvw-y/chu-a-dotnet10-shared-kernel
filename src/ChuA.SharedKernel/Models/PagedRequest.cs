// Copyright (c) 2026 Alvin Wilsen Chan Chua
// GitHub: chuaalvw-y
// Licensed under the Alvin Wilsen Chan Chua Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

namespace ChuA.SharedKernel.Models;

/// <summary>
/// Represents a paging request.
/// </summary>
/// <param name="PageNumber">The one-based page number.</param>
/// <param name="PageSize">The requested page size.</param>
public sealed record PagedRequest(int PageNumber = 1, int PageSize = 25)
{
    /// <summary>
    /// Gets the zero-based number of items to skip.
    /// </summary>
    public int Skip => (Math.Max(PageNumber, 1) - 1) * Math.Max(PageSize, 1);

    /// <summary>
    /// Creates a normalized paging request.
    /// </summary>
    /// <param name="defaultPageSize">The default page size.</param>
    /// <param name="maxPageSize">The maximum allowed page size.</param>
    /// <returns>A normalized request.</returns>
    public PagedRequest Normalize(int defaultPageSize, int maxPageSize)
    {
        var safeDefault = Math.Max(defaultPageSize, 1);
        var safeMax = Math.Max(maxPageSize, safeDefault);
        var page = Math.Max(PageNumber, 1);
        var size = PageSize <= 0 ? safeDefault : Math.Min(PageSize, safeMax);

        return new PagedRequest(page, size);
    }
}
