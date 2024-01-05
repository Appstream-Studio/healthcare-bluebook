using System.Security.Cryptography.X509Certificates;
using ITfoxtec.Identity.Saml2.MvcCore;
using ITfoxtec.Identity.Saml2.Util;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace AppStream.HealthcareBluebook.Certificate.CertFile;

internal class CertFileSigningCertificateProvider : ISigningCertificateProvider
{
    private readonly CertFileOptions _options;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public CertFileSigningCertificateProvider(
        IOptions<CertFileOptions> options,
        IWebHostEnvironment webHostEnvironment)
    {
        this._options = options.Value;
        this._webHostEnvironment = webHostEnvironment;
    }

    public X509Certificate2 GetSigingCertificate()
    {
        var certPath = this._webHostEnvironment.MapToPhysicalFilePath(this._options.FileName);
        return CertificateUtil.Load(
            certPath,
            this._options.Password,
            X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet);
    }
}
