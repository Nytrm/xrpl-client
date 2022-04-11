using RpcClient.Client;
using RpcClient.Services;
using RpcClient.Services.Interfaces;

namespace RpcClient;

using Client;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interfaces;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddClient(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHttpClient<RippleAccountClient>();

        serviceCollection.AddScoped<IXrpLedgerAccountService, XrpLedgerAccountService>();

        return serviceCollection;
    }
}