using AppStream.HealthcareBluebook.ServiceCollectionExtensions;
using Microsoft.Extensions.DependencyInjection;

namespace AppStream.HealthcareBluebook.Certificate.WindowsStore;

public static class WindowsStoreHcbbServiceBuilderExtensions
{
    public static IServiceCollection WithWindowsStoreCertificateProvider(this IHcbbServicesBuilder builder)
    {
        builder.Services
            .AddOptions<WindowsCertificateStoreOptions>()
            .BindConfiguration(WindowsCertificateStoreOptions.OptionsName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return builder.Services.AddScoped<ISigningCertificateProvider, WindowsStoreSigningCertificateProvider>();
    }
}
