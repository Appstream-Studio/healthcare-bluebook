using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Options;

namespace AppStream.HealthcareBluebook.Certificate.WindowsStore;

internal class WindowsStoreSigningCertificateProvider : ISigningCertificateProvider
{
    private readonly WindowsCertificateStoreOptions _options;

    public WindowsStoreSigningCertificateProvider(IOptions<WindowsCertificateStoreOptions> options)
    {
        this._options = options.Value;
    }

    public X509Certificate2 GetSigingCertificate()
    {
        using var store = new X509Store(this._options.StoreName, this._options.StoreLocation);
        store.Open(OpenFlags.ReadOnly);
        var certCollection = store.Certificates.Find(this._options.FindType, this._options.FindValue, validOnly: false);
        if (certCollection.Count == 0)
        {
            throw new CertificateNotFoundException(
                "Cannot get signing certificate from Windows certificate store." +
                $"Finding certificate by find type: '{this._options.FindType}' and find value: '{this._options.FindValue}'" +
                $"in store (location: '{this._options.StoreLocation}', name: '{this._options.StoreName}') returned 0 results.");
        }

        return certCollection[0];
    }
}
