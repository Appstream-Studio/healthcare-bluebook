using ITfoxtec.Identity.Saml2.Cryptography;

namespace AppStream.HealthcareBluebook.Certificate;

internal interface ISigningCertificateProvider
{
    Saml2X509Certificate GetSigingCertificate();
}
