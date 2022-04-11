using System.Text.Json.Serialization;

namespace RpcClient.Models.AccountCurrencies;

/// <summary>
/// The currencies that an account can send or receive are defined based on a check of its trust lines.
/// If an account has a trust line for a currency and enough room to increase its balance, it can receive that currency.
/// If the trust line's balance can go down, the account can send that currency.
/// This method doesn't check whether the trust line is frozen or authorized.
/// </summary>
public class AccountCurrenciesResult
{
    /// <summary>
    /// (May be omitted) The identifying hash of the ledger version used to retrieve this data, as hex.
    /// </summary>
    [JsonPropertyName("ledger_hash")]
    public string? LedgerHash { get; set; }

    /// <summary>
    /// The ledger index of the ledger version used to retrieve this data.
    /// </summary>
    [JsonPropertyName("ledger_index")]
    public int LedgerIndex { get; set; }

    /// <summary>
    /// Array of Currency Codes for currencies that this account can receive.
    /// </summary>
    [JsonPropertyName("receive_currencies")]
    public List<string> ReceiveCurrencies { get; set; }
    
    /// <summary>
    /// Array of Currency Codes for currencies that this account can send.
    /// </summary>
    [JsonPropertyName("send_currencies")]
    public List<string> SendCurrencies { get; set; }
    
    /// <summary>
    /// If true, this data comes from a validated ledger.
    /// </summary>
    [JsonPropertyName("validated")]
    public bool Validated { get; set; }

    /// <summary>
    /// The request status.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }
}