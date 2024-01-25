using AppStream.HealthcareBluebook.Certificate;
using AppStream.HealthcareBluebook.Certificate.CertFile;
using AppStream.HealthcareBluebook.ServiceCollectionExtensions;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace AppStream.HealthcareBluebook;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class CertFileHcbbServiceBuilderExtensions
{
    public static IServiceCollection WithCertFileCertificateProvider(this IHcbbServicesBuilder builder)
    {
        builder.Services
            .AddOptions<CertFileOptions>()
            .BindConfiguration(CertFileOptions.OptionsName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return builder.Services.AddScoped<ISigningCertificateProvider, CertFileSigningCertificateProvider>();
    }
}
