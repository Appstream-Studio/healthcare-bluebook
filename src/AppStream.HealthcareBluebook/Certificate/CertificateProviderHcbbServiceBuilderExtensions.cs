using AppStream.HealthcareBluebook.ServiceCollectionExtensions;
using Microsoft.Extensions.DependencyInjection;

namespace AppStream.HealthcareBluebook.Certificate;

/// <summary>
/// Extension methods for adding a custom certificate provider to the HealthcareBluebook services builder.
/// </summary>
public static class CertificateProviderHcbbServiceBuilderExtensions
{
    /// <summary>
    /// Adds a certificate provider to the HealthcareBluebook services builder.
    /// </summary>
    /// <typeparam name="TCertificateProvider">The type of certificate provider to add.</typeparam>
    /// <param name="builder">The HealthcareBluebook services builder.</param>
    /// <returns>The HealthcareBluebook services builder.</returns>
    public static IServiceCollection WithCertificateProvider<TCertificateProvider>(this IHcbbServicesBuilder builder)
        where TCertificateProvider : class, ISigningCertificateProvider
    {
        return builder.Services.AddScoped<ISigningCertificateProvider, TCertificateProvider>();
    }
}
