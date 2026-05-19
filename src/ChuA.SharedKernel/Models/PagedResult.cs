namespace ChuA.SharedKernel.Models;

/// <summary>
/// Represents a page of items with total count metadata.
/// </summary>
/// <typeparam name="T">The item type.</typeparam>
/// <param name="Items">The current page items.</param>
/// <param name="TotalCount">The total number of available items.</param>
/// <param name="PageNumber">The one-based page number.</param>
/// <param name="PageSize">The page size.</param>
public sealed record PagedResult<T>(IReadOnlyCollection<T> Items, int TotalCount, int PageNumber, int PageSize)
{
    /// <summary>
    /// Gets the total number of pages.
    /// </summary>
    public int TotalPages => PageSize <= 0 ? 0 : (int)Math.Ceiling(TotalCount / (double)PageSize);

    /// <summary>
    /// Gets a value indicating whether a previous page exists.
    /// </summary>
    public bool HasPreviousPage => PageNumber > 1;

    /// <summary>
    /// Gets a value indicating whether a next page exists.
    /// </summary>
    public bool HasNextPage => PageNumber < TotalPages;
}
