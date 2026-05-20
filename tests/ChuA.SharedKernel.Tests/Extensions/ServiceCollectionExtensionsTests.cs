// Copyright (c) 2026 Alvin Wilsen Chan Chua
// GitHub: chuaalvw-y
// Licensed under the Alvin Wilsen Chan Chua Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

using ChuA.SharedKernel.Abstractions;
using ChuA.SharedKernel.Configuration;
using ChuA.SharedKernel.Constants;
using ChuA.SharedKernel.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ChuA.SharedKernel.Tests.Extensions;

public sealed class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddChuASharedKernel_binds_default_section_and_registers_services()
    {
        var services = new ServiceCollection();
        var configuration = BuildConfiguration(new Dictionary<string, string?>
        {
            [$"{SharedKernelDefaults.ConfigurationSectionName}:ApplicationName"] = "Orders.Api",
            [$"{SharedKernelDefaults.ConfigurationSectionName}:EnvironmentName"] = "Test",
            [$"{SharedKernelDefaults.ConfigurationSectionName}:CorrelationHeaderName"] = "X-Test-Correlation",
            [$"{SharedKernelDefaults.ConfigurationSectionName}:DefaultPageSize"] = "10",
            [$"{SharedKernelDefaults.ConfigurationSectionName}:MaxPageSize"] = "100",
            [$"{SharedKernelDefaults.ConfigurationSectionName}:ClockKind"] = "Utc"
        });

        services.AddChuASharedKernel(configuration);

        using var provider = services.BuildServiceProvider(new ServiceProviderOptions { ValidateScopes = true });
        var options = provider.GetRequiredService<IOptions<SharedKernelOptions>>().Value;

        Assert.Equal("Orders.Api", options.ApplicationName);
        Assert.Equal("Test", options.EnvironmentName);
        Assert.Equal("X-Test-Correlation", options.CorrelationHeaderName);
        Assert.Equal(10, options.DefaultPageSize);
        Assert.Equal(100, options.MaxPageSize);
        Assert.NotNull(provider.GetRequiredService<IClock>());

        using var scope = provider.CreateScope();
        Assert.NotNull(scope.ServiceProvider.GetRequiredService<ICorrelationIdProvider>());
        Assert.False(scope.ServiceProvider.GetRequiredService<ICurrentUserProvider>().IsAuthenticated);
    }

    [Fact]
    public void AddChuASharedKernel_binds_custom_section()
    {
        var services = new ServiceCollection();
        var configuration = BuildConfiguration(new Dictionary<string, string?>
        {
            ["Platform:Kernel:ApplicationName"] = "Worker",
            ["Platform:Kernel:EnvironmentName"] = "Development"
        });

        services.AddChuASharedKernel(configuration, "Platform:Kernel");

        using var provider = services.BuildServiceProvider();
        var options = provider.GetRequiredService<IOptions<SharedKernelOptions>>().Value;

        Assert.Equal("Worker", options.ApplicationName);
        Assert.Equal("Development", options.EnvironmentName);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void AddChuASharedKernel_rejects_blank_section_names(string sectionName)
    {
        var services = new ServiceCollection();
        var configuration = BuildConfiguration([]);

        Assert.Throws<ArgumentException>(() => services.AddChuASharedKernel(configuration, sectionName));
    }

    private static IConfiguration BuildConfiguration(Dictionary<string, string?> values) =>
        new ConfigurationBuilder()
            .AddInMemoryCollection(values)
            .Build();
}
