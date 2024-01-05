using System.Security.Cryptography.X509Certificates;
using Azure.Identity;
using Azure.Security.KeyVault.Certificates;
using ITfoxtec.Identity.Saml2.Cryptography;
using Microsoft.Extensions.Options;
using RSAKeyVaultProvider;

namespace AppStream.HealthcareBluebook.Certificate.AzureKeyVault;

internal class AzureKeyVaultSigningCertificateProvider : ISigningCertificateProvider
{
    private readonly AzureKeyVaultOptions _options;

    public AzureKeyVaultSigningCertificateProvider(IOptions<AzureKeyVaultOptions> options)
    {
        this._options = options.Value;
    }

    public X509Certificate2 GetSigingCertificate()
    {
        var keyVaultCredential = new DefaultAzureCredential(new DefaultAzureCredentialOptions
        {
            ExcludeManagedIdentityCredential = true
        });

        var certificateClient = new CertificateClient(new Uri(this._options.KeyVaultUrl), keyVaultCredential);
        var certificateWithPolicy = certificateClient.GetCertificate(this._options.CertificateName);

#pragma warning disable CA2000 // Dispose objects before losing scope; Certs are needed outside this scope
        var publicCertificate = new X509Certificate2(certificateWithPolicy.Value.Cer);
        var rsa = RSAFactory.Create(
            credential: keyVaultCredential,
            keyId: certificateWithPolicy.Value.KeyId,
            key: new Azure.Security.KeyVault.Keys.JsonWebKey(publicCertificate.GetRSAPublicKey()));
#pragma warning restore CA2000 // Dispose objects before losing scope

        return new Saml2X509Certificate(publicCertificate, rsa);
    }
}
