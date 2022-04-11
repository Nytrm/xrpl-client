using Microsoft.AspNetCore.Mvc;

namespace WebApplicationOne.Controllers;

using RpcClient.Models.AccountChannel;
using RpcClient.Models.AccountCurrencies;
using RpcClient.Models.AccountLines;
using RpcClient.Services.Interfaces;

[ApiController]
[Route("test")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;
    private readonly IXrpLedgerAccountService _xrpLedgerAccountService;

    public TestController(ILogger<TestController> logger, IXrpLedgerAccountService  xrpLedgerAccountService)
    {
        _logger = logger;
        _xrpLedgerAccountService = xrpLedgerAccountService;
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
    public async Task<IActionResult> GetAccountLinesAsync([FromQuery] string account, [FromQuery] string currencyCode, [FromQuery] int limit = 50,CancellationToken cancellationToken = default)
    {
        var trustLines = new List<TrustLine>();
        await GetAllTrustLinesAsync(account, trustLines, null, cancellationToken);
        
        var topX = trustLines
            .Where(x => x.Currency.Equals(currencyCode))
            .DistinctBy(x => x.Account)
            .OrderByDescending(x => x.Balance)
            .Take(limit)
            .ToList();

        return Ok(topX);
    }

    private async Task GetAllTrustLinesAsync(string account, List<TrustLine> trustLines, string? marker = null, CancellationToken cancellationToken = default)
    {
        var response = await _xrpLedgerAccountService.GetAccountLinesAsync(new AccountLinesParameters
        {
            Account = account,
            Marker = marker
        }, cancellationToken);

        if (!response.Success)
        {
            return;
        }

        trustLines.AddRange(response.Result.Lines);

        // todo fix some issue with duplicated data
        if (response.Result.Marker == null || marker == response.Result.Marker)
        {
            return;
        }
        
        await GetAllTrustLinesAsync(account, trustLines, response.Result.Marker, cancellationToken);
    }
}