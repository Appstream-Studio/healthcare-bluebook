using System.ComponentModel.DataAnnotations;

namespace AppStream.HealthcareBluebook.Certificate.CertFile;

internal class CertFileOptions
{
    public const string OptionsName = "CertFile";

    /// <summary>
    /// Certificate file name.
    /// </summary>
    [Required]
    public required string FileName { get; set; }

    /// <summary>
    /// Certificate password.
    /// </summary>
    [Required]
    public required string Password { get; set; }
}
