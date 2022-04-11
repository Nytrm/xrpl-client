namespace RpcClient.DependencyInjection;

using Client;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interfaces;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddXrplAccountClient(this IServiceCollection serviceCollection)
    {
        // Add clients
        serviceCollection.AddHttpClient<XrplAccountClient>();

        serviceCollection.AddScoped<IXrpLedgerAccountService, XrpLedgerAccountService>();

        return serviceCollection;
    } 
}