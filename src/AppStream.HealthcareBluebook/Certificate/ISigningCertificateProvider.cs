using System.Security.Cryptography.X509Certificates;

namespace AppStream.HealthcareBluebook.Certificate;

/// <summary>
/// Interface for providing a signing certificate.
/// </summary>
public interface ISigningCertificateProvider
{
    /// <summary>
    /// Gets the signing certificate.
    /// </summary>
    /// <returns>The signing certificate.</returns>
    X509Certificate2 GetSigingCertificate();
}
