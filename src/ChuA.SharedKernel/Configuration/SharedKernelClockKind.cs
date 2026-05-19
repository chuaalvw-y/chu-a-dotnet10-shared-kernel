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
