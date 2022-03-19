using Client.Client;
using Client.Services;
using Client.Services.Interfaces;

namespace Client;

using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddClient(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHttpClient<RippleAccountClient>();

        serviceCollection.AddScoped<IXrpLedgerAccountService, XrpLedgerAccountService>();

        return serviceCollection;
    }
}