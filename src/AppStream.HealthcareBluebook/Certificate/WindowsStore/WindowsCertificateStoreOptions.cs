using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace AppStream.HealthcareBluebook.Certificate.WindowsStore;

public class WindowsCertificateStoreOptions
{
    public const string OptionsName = "WindowsCertificateStore";

    /// <summary>
    /// The name of the store.
    /// </summary>
    [Required]
    public required StoreName StoreName { get; set; }

    /// <summary>
    /// The location of the store.
    /// </summary>
    [Required]
    public required StoreLocation StoreLocation { get; set; }

    /// <summary>
    /// The type of search to be performed.
    /// </summary>
    [Required]
    public required X509FindType FindType { get; set; }

    /// <summary>
    /// The value to search for.
    /// </summary>
    [Required]
    public required string FindValue { get; set; }
}
