namespace RpcClient.Services.Interfaces;

using Models;
using Models.AccountChannel;
using Models.AccountCurrencies;
using Models.AccountLines;
using Models.AccountObjects;
using Models.AccountOffers;

public interface IXrpLedgerAccountService
{
    Task<Response<AccountCurrenciesResult>> GetAccountCurrenciesAsync(AccountCurrenciesParameters parameters, CancellationToken cancellationToken = default);

    Task<Response<AccountChannelResult>> GetAccountChannelsAsync(AccountChannelParameters parameters, CancellationToken cancellationToken = default);

    Task<Response<AccountLinesResult>> GetAccountLinesAsync(AccountLinesParameters parameters, CancellationToken cancellationToken = default);
    
    Task<Response<AccountObjectsResult>> GetAccountObjectsAsync(AccountObjectsParameters parameters, CancellationToken cancellationToken = default);
    
    Task<Response<AccountOffersResult>> GetAccountOffersAsync(AccountOffersParameters parameters, CancellationToken cancellationToken = default);
}