using AppStream.HealthcareBluebook.ServiceCollectionExtensions;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace AppStream.HealthcareBluebook;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class HcbbServiceCollectionExtensions
{
    public static IHcbbServicesBuilder AddHealthcareBluebook(this IServiceCollection services)
    {
        services
            .AddOptions<HcbbSamlOptions>()
            .BindConfiguration(HcbbSamlOptions.OptionsName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services
            .AddScoped<ISamlConfigurationProvider, SamlConfigurationProvider>()
            .AddScoped<IHcbbSamlResponseGenerator, HcbbSamlResponseGenerator>();

        return new HcbbServicesBuilder(services);
    }
}
