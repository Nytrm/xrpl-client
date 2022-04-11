namespace RpcClient.Services;

using Client;
using Interfaces;
using Models;
using Models.AccountChannel;
using Models.AccountCurrencies;
using Models.AccountLines;
using Models.AccountObjects;
using Models.AccountOffers;

public class XrpLedgerAccountService : IXrpLedgerAccountService
{
    private readonly XrplAccountClient _client;

    public XrpLedgerAccountService(XrplAccountClient client)
    {
        _client = client;
    }

    public async Task<Response<AccountChannelResult>> GetAccountChannelsAsync(AccountChannelParameters parameters, CancellationToken cancellationToken = default)
        => await ExecuteAsync<AccountChannelResult>("account_channels", parameters, cancellationToken);

    public async Task<Response<AccountCurrenciesResult>> GetAccountCurrenciesAsync(AccountCurrenciesParameters parameters, CancellationToken cancellationToken = default)
        => await ExecuteAsync<AccountCurrenciesResult>("account_currencies", parameters, cancellationToken);
    
    public async Task<Response<AccountLinesResult>> GetAccountLinesAsync(AccountLinesParameters parameters, CancellationToken cancellationToken = default)
        => await ExecuteAsync<AccountLinesResult>("account_lines", parameters, cancellationToken);

    public async Task<Response<AccountObjectsResult>> GetAccountObjectsAsync(AccountObjectsParameters parameters, CancellationToken cancellationToken = default)
        => await ExecuteAsync<AccountObjectsResult>("account_objects", parameters, cancellationToken);

    public async Task<Response<AccountOffersResult>> GetAccountOffersAsync(AccountOffersParameters parameters, CancellationToken cancellationToken = default)
        => await ExecuteAsync<AccountOffersResult>("account_offers", parameters, cancellationToken);

    private async Task<Response<T>> ExecuteAsync<T>(string method, object parameters, CancellationToken cancellationToken) where T : class
    {
        var request = new Request
        {
            Method = method,
            Parameters = new List<object>
            {
                parameters
            }
        };

        return await _client.PostAsync<T>(request, cancellationToken);
    }
}