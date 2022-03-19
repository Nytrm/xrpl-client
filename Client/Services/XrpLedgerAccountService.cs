using Client.Client;
using Client.Models;
using Client.Services.Interfaces;

namespace Client.Services;

public class XrpLedgerAccountService : IXrpLedgerAccountService
{
    private readonly RippleAccountClient _client;

    public XrpLedgerAccountService(RippleAccountClient client)
    {
        _client = client;
    }

    public async Task<Models.AccountChannel.Response?> GetAccountChannelsAsync(
        Models.AccountChannel.Parameters parameters, CancellationToken cancellationToken = default) =>
        await ExecuteAsync<Models.AccountChannel.Response>("account_channels", parameters, cancellationToken);

    public async Task<Models.AccountCurrencies.Response?> GetAccountCurrenciesAsync(
        Models.AccountCurrencies.Parameters parameters, CancellationToken cancellationToken = default) =>
        await ExecuteAsync<Models.AccountCurrencies.Response>("account_currencies", parameters, cancellationToken);

    private async Task<T?> ExecuteAsync<T>(string method, IRequestParameters parameters,
        CancellationToken cancellationToken) where T : IResponseResult
    {
        var request = new Request
        {
            Method = method,
            Parameters = parameters
        };

        return await _client.PostAsync<T>(request, cancellationToken);
    }
}