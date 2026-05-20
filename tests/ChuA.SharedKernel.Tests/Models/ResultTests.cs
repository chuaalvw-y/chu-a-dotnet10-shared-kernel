// Copyright (c) 2026 Alvin Wilsen Chan Chua
// GitHub: chuaalvw-y
// Licensed under the Alvin Wilsen Chan Chua Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

using ChuA.SharedKernel.Models;

namespace ChuA.SharedKernel.Tests.Models;

public sealed class ResultTests
{
    [Fact]
    public void Success_creates_successful_result_without_errors()
    {
        var result = Result.Success();

        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Failure_requires_at_least_one_real_error()
    {
        Assert.Throws<ArgumentException>(() => Result.Failure([Error.None]));
    }

    [Fact]
    public void Result_value_throws_when_failed()
    {
        var result = Result<int>.Failure(new Error("Numbers.Invalid", "The number is invalid."));

        Assert.Throws<InvalidOperationException>(() => result.Value);
    }

    [Fact]
    public void Result_value_returns_value_when_successful()
    {
        var result = Result<int>.Success(42);

        Assert.Equal(42, result.Value);
    }
}
