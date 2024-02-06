namespace AppStream.HealthcareBluebook.Certificate.WindowsStore;

public class CertificateNotFoundException : Exception
{
    public CertificateNotFoundException(string? message) : base(message)
    {
    }
}
