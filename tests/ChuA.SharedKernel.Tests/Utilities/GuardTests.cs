using ChuA.SharedKernel.Utilities;

namespace ChuA.SharedKernel.Tests.Utilities;

public sealed class GuardTests
{
    [Fact]
    public void AgainstNull_returns_value_when_not_null()
    {
        var value = new object();

        Assert.Same(value, Guard.AgainstNull(value, nameof(value)));
    }

    [Fact]
    public void AgainstNullOrWhiteSpace_throws_for_blank_values()
    {
        Assert.Throws<ArgumentException>(() => Guard.AgainstNullOrWhiteSpace(" ", "name"));
    }

    [Fact]
    public void AgainstNegativeOrZero_throws_for_zero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Guard.AgainstNegativeOrZero(0, "count"));
    }
}
