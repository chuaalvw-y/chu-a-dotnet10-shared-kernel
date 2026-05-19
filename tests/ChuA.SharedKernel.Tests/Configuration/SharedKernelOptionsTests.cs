using ChuA.SharedKernel.Configuration;
using Microsoft.Extensions.Options;

namespace ChuA.SharedKernel.Tests.Configuration;

public sealed class SharedKernelOptionsTests
{
    [Fact]
    public void Validator_succeeds_when_default_page_size_is_not_greater_than_maximum()
    {
        var validator = new SharedKernelOptionsValidator();
        var result = validator.Validate(null, new SharedKernelOptions
        {
            DefaultPageSize = 10,
            MaxPageSize = 20
        });

        Assert.Equal(ValidateOptionsResult.Success, result);
    }

    [Fact]
    public void Validator_fails_when_default_page_size_is_greater_than_maximum()
    {
        var validator = new SharedKernelOptionsValidator();
        var result = validator.Validate(null, new SharedKernelOptions
        {
            DefaultPageSize = 50,
            MaxPageSize = 20
        });

        Assert.True(result.Failed);
        Assert.Contains(nameof(SharedKernelOptions.DefaultPageSize), result.FailureMessage);
    }
}
