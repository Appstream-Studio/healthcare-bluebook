using System.ComponentModel.DataAnnotations;

namespace AppStream.HealthcareBluebook.Certificate.AzureKeyVault;

public class AzureKeyVaultOptions
{
    public const string OptionsName = "AzureKeyVault";

    /// <summary>
    /// Name of the certificate in the key vault.
    /// </summary>
    [Required]
    public required string CertificateName { get; set; }

    /// <summary>
    /// Url to the key vault.
    /// </summary>
    [Required]
    public required string KeyVaultUrl { get; set; }
}
