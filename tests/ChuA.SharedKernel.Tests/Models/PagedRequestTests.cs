// Copyright (c) 2026 Alvin Wilsen Chan Chua
// GitHub: chuaalvw-y
// Licensed under the Alvin Wilsen Chan Chua Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

using ChuA.SharedKernel.Models;

namespace ChuA.SharedKernel.Tests.Models;

public sealed class PagedRequestTests
{
    [Theory]
    [InlineData(0, 0, 1, 25)]
    [InlineData(-2, -10, 1, 25)]
    [InlineData(3, 500, 3, 100)]
    public void Normalize_safely_bounds_invalid_values(int page, int size, int expectedPage, int expectedSize)
    {
        var normalized = new PagedRequest(page, size).Normalize(defaultPageSize: 25, maxPageSize: 100);

        Assert.Equal(expectedPage, normalized.PageNumber);
        Assert.Equal(expectedSize, normalized.PageSize);
    }
}
