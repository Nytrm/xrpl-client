namespace Client.Services.Interfaces;

public interface IXrpLedgerAccountService
{
    Task<Models.AccountCurrencies.Response?> GetAccountCurrenciesAsync(
        Models.AccountCurrencies.Parameters parameters, CancellationToken cancellationToken = default);

    Task<Models.AccountChannel.Response?> GetAccountChannelsAsync(
        Models.AccountChannel.Parameters parameters, CancellationToken cancellationToken = default);
}