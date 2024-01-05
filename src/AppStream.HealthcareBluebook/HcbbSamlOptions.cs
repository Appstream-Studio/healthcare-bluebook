using System.ComponentModel.DataAnnotations;
using ITfoxtec.Identity.Saml2.Schemas;

namespace AppStream.HealthcareBluebook;

public class HcbbSamlOptions
{
    public const string OptionsName = "HcbbSaml";

    /// <summary>
    /// ClientId SAML assertion attribute name.
    /// </summary>
    [Required]
    public required string ClientIdAttributeName { get; set; } = "clientid";

    /// <summary>
    /// ClientId SAML assertion attribute name. This is your app's client id in HCBB system.
    /// </summary>
    [Required]
    public required string ClientIdAttributeValue { get; set; }

    /// <summary>
    /// MemberId SAML assertion attribute name.
    /// </summary>
    [Required]
    public required string MemberIdAttributeName { get; set; } = "memberid";

    /// <summary>
    /// SAML assertion audience.
    /// </summary>
    [Required]
    public required string Audience { get; set; } = "healthcarebluebook:SAML20:TEST";

    /// <summary>
    /// SAML issuer.
    /// </summary>
    [Required]
    public required string Issuer { get; set; }

    /// <summary>
    /// SSO destination.
    /// </summary>
    [Required]
    public required string SingleSignOnDestination { get; set; } = "https://test.healthcarebluebook.com/sso/test/BPA/default.aspx";

    /// <summary>
    /// Signature algorithm.
    /// </summary>
    [Required]
    public required string SignatureAlgorithm { get; set; } = Saml2SecurityAlgorithms.RsaSha256Signature;
}
