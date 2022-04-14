using Microsoft.AspNetCore.Mvc;

namespace WebApplicationOne.Controllers;

using RpcClient.Models;
using RpcClient.Models.AccountChannel;
using RpcClient.Models.AccountCurrencies;
using RpcClient.Models.AccountLines;
using RpcClient.Services.Interfaces;

[ApiController]
[Route("example")]
public class ExampleController : ControllerBase
{
    private readonly ILogger<ExampleController> _logger;
    private readonly IXrpLedgerAccountService _xrpLedgerAccountService;

    public ExampleController(IXrpLedgerAccountService  xrpLedgerAccountService, ILogger<ExampleController> logger)
    {
        _xrpLedgerAccountService = xrpLedgerAccountService;
        _logger = logger;
    }

    [HttpGet("account_channels")]
    public async Task<IActionResult> GetAccountChannelsAsync(CancellationToken cancellationToken = default)
    {
        var response = await _xrpLedgerAccountService.GetAccountChannelsAsync(new AccountChannelParameters
        {
            Account = "rN7n7otQDd6FczFgLdSqtcsAUxDkw6fzRH",
            DestinationAccount = "rf1BiGeXwwQoi8Z2ueFYTEXSwuJYfV2Jpn",
            LedgerIndex = "validated"
        }, cancellationToken);

        return response.Success ? Ok(response.Result) : BadRequest(response.Error);
    }
    
    [HttpGet("account_currencies")]
    public async Task<IActionResult> GetAccountCurrenciesAsync(CancellationToken cancellationToken = default)
    {
        var response = await _xrpLedgerAccountService.GetAccountCurrenciesAsync(new AccountCurrenciesParameters
        {
            Account = "rGEekk1PRyozC1ZEZCXL7EZcko4rrrETGh",
            LedgerIndex = "validated",
            Strict = true
        }, cancellationToken);

        return response.Success ? Ok(response.Result) : BadRequest(response.Error);
    }
    
    [HttpGet("account_lines")]
    public async Task<IActionResult> GetAccountLinesAsync(CancellationToken cancellationToken = default)
    {
        var response = await _xrpLedgerAccountService.GetAccountLinesAsync(new AccountLinesParameters
        {
            Account = "rGEekk1PRyozC1ZEZCXL7EZcko4rrrETGh"
        }, cancellationToken);

        return response.Success ? Ok(response.Result) : BadRequest(response.Error);
    }
    
    [HttpGet("top_trustlines_issuer")]
    public async Task<IActionResult> GetAccountLinesAsync([FromQuery] string account, [FromQuery] string currencyCode, [FromQuery] int limit = 50, CancellationToken cancellationToken = default)
    {
        var trustLines = await GetAllTrustLinesAsync(account, cancellationToken);

        var topX = trustLines
            .Where(x => x.Currency.Equals(currencyCode))
            .DistinctBy(x => x.Account)
            .OrderBy(x => x.BalanceAsNumber)
            .Take(limit)
            .ToList();

        return Ok(topX);
    }

    private async Task<List<TrustLine>> GetAllTrustLinesAsync(string account, CancellationToken cancellationToken = default)
    {
        var trustLines = new List<TrustLine>();
        var fetchMore = true;
        object? marker = null;
        while (fetchMore)
        {
            var response = await _xrpLedgerAccountService.GetAccountLinesAsync(new AccountLinesParameters
            {
                Account = account,
                Marker = marker
            }, cancellationToken);

            var count = response.Result?.Lines?.Count ?? 0;
            
            // get current marker
            marker = response.Result?.Marker;
            // check if count is higher than zero and if marker is not null
            fetchMore = count > 0 && marker != null;
            
            _logger.LogInformation("Fetched # TrustLines: {Count},{Marker}", count, marker);
            
            if (count > 0)
            {
                trustLines.AddRange(response.Result!.Lines!);
            }
        }

        return trustLines;
    }
}