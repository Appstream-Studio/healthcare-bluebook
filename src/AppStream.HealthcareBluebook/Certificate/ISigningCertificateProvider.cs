using System.Security.Cryptography.X509Certificates;

namespace AppStream.HealthcareBluebook.Certificate;

internal interface ISigningCertificateProvider
{
    X509Certificate2 GetSigingCertificate();
}
