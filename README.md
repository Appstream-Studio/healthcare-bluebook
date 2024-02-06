[![AppStream Studio](https://raw.githubusercontent.com/Appstream-Studio/healthcare-bluebook/main/assets/banner.jpg)](https://appstream.studio/)
[![License](https://img.shields.io/badge/license-apache-green)](https://github.com/Appstream-Studio/healthcare-bluebook/blob/main/LICENSE)
[![NuGet Package](https://img.shields.io/nuget/v/appstream.healthcarebluebook.svg)](https://www.nuget.org/packages/AppStream.HealthcareBluebook/)

# AppStream.HealthcareBluebook Library

`AppStream.HealthcareBluebook` is an open-source .NET Core library designed to simplify the integration process with Healthcare Bluebook's Single Sign-On (SSO) system using SAML 2.0. The library provides an easy-to-use interface to seamlessly integrate your web application with Healthcare Bluebook's SSO.

## Acknowledgements

This library relies heavily on the excellent work done by the [ITfoxtec.Identity.Saml2.MvcCore](https://github.com/ITfoxtec/ITfoxtec.Identity.Saml2) project. We extend our sincere appreciation to the contributors and maintainers of this library for providing a solid foundation for SAML 2.0 integration in ASP.NET Core applications.

## Getting Started

Follow these simple steps to integrate AppStream.HealthcareBluebook into your web application.

### 1. Installation

Install the AppStream.HealthcareBluebook NuGet package in your .NET Core web application using the following command:

```bash
dotnet add package AppStream.HealthcareBluebook
```

### 2. Configuration

In your web app's startup code, add the following lines based on your certificate storage preference:

If your signing certificate is on your machine:
```csharp
builder.Services
    .AddHealthcareBluebook()
    .WithCertFileCertificateProvider();
```

If your signing certificate is in Azure Key Vault:
```csharp
builder.Services
    .AddHealthcareBluebook()
    .WithAzureKeyVaultCertificateProvider();
```

If you signing certificate is in Windows certificate store:
```csharp
builder.Services
    .AddHealthcareBluebook()
    .WithWindowsStoreCertificateProvider();
```

You can also create and use your own implementation of `ISigningCertificateProvider`:
```csharp
builder.Services
    .AddHealthcareBluebook()
    .WithCertificateProvider<YourSigningCertificateProvider>();
```

### 3. App Settings

Configure your app settings in your `appsettings.json` or equivalent configuration file:

```json
{
  "HcbbSaml": {
    "Audience": ">> HCBB audience <<",
    "ClientIdAttributeName": "clientid",
    "ClientIdAttributeValue": ">> your client id <<",
    "Issuer": ">> your saml 'issuer' value <<",
    "MemberIdAttributeName": "memberid",
    "SignatureAlgorithm": "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256",
    "SingleSignOnDestination": "url to HCBB SSO"
  },
  "AzureKeyVault": { // needed only when using AzureKeyVaultSigningCertificateProvider
    "CertificateName": ">> name of the cert in the key vault <<",
    "KeyVaultUrl": ">> url to your key vault <<"
  },
  "CertFile": { // needed only when using CertFileSigningCertificateProvider
    "FileName": "cert file name",
    "Password": "cert passwrd"
  },
  "WindowsCertificateStore": { // needed only when using WindowsStoreSigningCertificateProvider
    "StoreName": "Me",
    "StoreLocation": "LocalMachine",
    "FindType": "FindByThumbprint",
    "FindValue": "cert thumbprint"
  }
}
```

### 4. Integration

Inject `IHcbbSamlResponseGenerator` into your controller and return the SAML response to the browser:

```csharp
public class HomeController : Controller
{ 
    private readonly IHcbbSamlResponseGenerator _hcbbSamlResponseGenerator;

    public HomeController(IHcbbSamlResponseGenerator hcbbSamlResponseGenerator)
    {
        _hcbbSamlResponseGenerator = hcbbSamlResponseGenerator;
    }

    public IActionResult GoToHcbb()
    {
        return _hcbbSamlResponseGenerator
            .GenerateHcbbSamlResponse("insert member id here");
    }
}
```

Feel free to contribute to this library! Please do open issues and submit your pull requests so this library can become a robust integartion tool 🚀