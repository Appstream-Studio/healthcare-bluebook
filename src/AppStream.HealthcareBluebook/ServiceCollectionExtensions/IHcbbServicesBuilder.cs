using Microsoft.Extensions.DependencyInjection;

namespace AppStream.HealthcareBluebook.ServiceCollectionExtensions;

public interface IHcbbServicesBuilder
{
    IServiceCollection Services { get; }
}

internal class HcbbServicesBuilder : IHcbbServicesBuilder
{
    private readonly IServiceCollection _services;

    public HcbbServicesBuilder(IServiceCollection services)
    {
        this._services = services;
    }

    public IServiceCollection Services => this._services;
}
