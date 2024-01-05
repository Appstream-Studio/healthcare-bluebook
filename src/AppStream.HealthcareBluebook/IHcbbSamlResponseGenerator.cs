using ITfoxtec.Identity.Saml2.Schemas;
using ITfoxtec.Identity.Saml2;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens.Saml2;
using ITfoxtec.Identity.Saml2.MvcCore;

namespace AppStream.HealthcareBluebook;

public interface IHcbbSamlResponseGenerator
{
    IActionResult GenerateHcbbSamlResponse(string memberId);
}

internal class HcbbSamlResponseGenerator : IHcbbSamlResponseGenerator
{
    private readonly HcbbSamlOptions _samlOptions;
    private readonly ISamlConfigurationProvider _configurationProvider;

    public HcbbSamlResponseGenerator(
        HcbbSamlOptions samlOptions,
        ISamlConfigurationProvider configurationProvider)
    {
        this._samlOptions = samlOptions;
        this._configurationProvider = configurationProvider;
    }

    public IActionResult GenerateHcbbSamlResponse(string memberId)
    {
        ArgumentNullException.ThrowIfNull(nameof(memberId));

        var saml2Configuration = this._configurationProvider.GetSaml2Configuration();
        var saml2AuthnResponse = new Saml2AuthnResponse(saml2Configuration)
        {
            Status = Saml2StatusCodes.Success,
            Destination = saml2Configuration.SingleSignOnDestination
        };

        saml2AuthnResponse.NameId = new Saml2NameIdentifier(memberId, NameIdentifierFormats.Persistent);
        saml2AuthnResponse.ClaimsIdentity = this.GenerateUserClaimsIdentity(memberId);

        var token = saml2AuthnResponse
            .CreateSecurityToken(
                saml2Configuration.AllowedAudienceUris.Single().ToString(),
                subjectConfirmationLifetime: 15,
                issuedTokenLifetime: 60);

        return new Saml2PostBinding()
            .Bind(saml2AuthnResponse)
            .ToActionResult();
    }

    private ClaimsIdentity GenerateUserClaimsIdentity(string memberId)
    {
        var claims = new[]
        {
            new Claim(this._samlOptions.ClientIdAttributeName, this._samlOptions.ClientIdAttributeValue),
            new Claim(this._samlOptions.MemberIdAttributeName, memberId)
        };

        return new ClaimsIdentity(claims);
    }
}
