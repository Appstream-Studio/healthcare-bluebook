using AppStream.HealthcareBluebook.Certificate;
using ITfoxtec.Identity.Saml2;
using Microsoft.Extensions.Options;

namespace AppStream.HealthcareBluebook;

internal interface ISamlConfigurationProvider
{
    Saml2Configuration GetSaml2Configuration();
}

internal class SamlConfigurationProvider : ISamlConfigurationProvider
{
    private readonly HcbbSamlOptions _samlOptions;
    private readonly ISigningCertificateProvider _certificateProvider;

    public SamlConfigurationProvider(
        IOptions<HcbbSamlOptions> samlOptionsProvider,
        ISigningCertificateProvider certificateProvider)
    {
        this._samlOptions = samlOptionsProvider.Value;
        this._certificateProvider = certificateProvider;
    }

    public Saml2Configuration GetSaml2Configuration()
    {
        var signingCertificate = this._certificateProvider.GetSigingCertificate();
        var saml2Configuration = new Saml2Configuration
        {
            AllowedIssuer = this._samlOptions.Issuer,
            Issuer = this._samlOptions.Issuer,
            SignatureAlgorithm = this._samlOptions.SignatureAlgorithm,
            SigningCertificate = signingCertificate,
            SingleSignOnDestination = new Uri(this._samlOptions.SingleSignOnDestination)
        };

        saml2Configuration.AllowedAudienceUris.Add(this._samlOptions.Audience);

        return saml2Configuration;
    }
}
