using ChuA.SharedKernel.Abstractions;
using ChuA.SharedKernel.Configuration;
using ChuA.SharedKernel.Constants;
using ChuA.SharedKernel.Providers;
using ChuA.SharedKernel.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ChuA.SharedKernel.Extensions;

/// <summary>
/// Provides service registration methods for the shared kernel.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers shared kernel services using the default configuration section.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The application configuration.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddChuASharedKernel(
        this IServiceCollection services,
        IConfiguration configuration) =>
        services.AddChuASharedKernel(configuration, SharedKernelDefaults.ConfigurationSectionName);

    /// <summary>
    /// Registers shared kernel services using a custom configuration section name.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The application configuration.</param>
    /// <param name="sectionName">The configuration section name.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddChuASharedKernel(
        this IServiceCollection services,
        IConfiguration configuration,
        string sectionName)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);

        if (string.IsNullOrWhiteSpace(sectionName))
        {
            throw new ArgumentException("Configuration section name is required.", nameof(sectionName));
        }

        services.AddOptions<SharedKernelOptions>()
            .Bind(configuration.GetSection(sectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddSingleton<IValidateOptions<SharedKernelOptions>, SharedKernelOptionsValidator>();
        services.AddSingleton<IClock, SystemClock>();
        services.AddScoped<ICorrelationIdProvider, CorrelationIdProvider>();
        services.AddScoped<ICurrentUserProvider, NullCurrentUserProvider>();

        return services;
    }
}
