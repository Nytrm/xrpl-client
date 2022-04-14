using System.Text.Json.Serialization;

namespace RpcClient.Models.AccountOffers;

public class AccountOffersParameters
{
    /// <summary>
    /// A unique identifier for the account, most commonly the account's address.
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; set; }
    
    /// <summary>
    /// (Optional) A 20-byte hex string for the ledger version to use. (See Specifying Ledgers)
    /// </summary>
    [JsonPropertyName("ledger_hash")]
    public string LedgerHash { get; set; }
    
    /// <summary>
    /// (Optional, defaults to current) The ledger index of the ledger to use, or "current", "closed", or "validated" to select a ledger dynamically. (See Specifying Ledgers)
    /// </summary>
    [JsonPropertyName("ledger_index")]
    public string LedgerIndex { get; set; }
    
    /// <summary>
    /// (Optional) The maximum number of objects to include in the results.
    /// Must be within the inclusive range 10 to 400 on non-admin connections. The default is 200.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }
    
    /// <summary>
    /// (May be omitted) Server-defined value for pagination.
    /// Pass this to the next call to resume getting results where this call left off.
    /// Omitted when there are no additional pages after this one.
    /// </summary>
    [JsonPropertyName("marker")]
    public object? Marker { get; set; }
    
    /// <summary>
    /// (Optional) If true, then the account field only accepts a public key or XRP Ledger address. Otherwise, account can be a secret or passphrase (not recommended).
    /// The default is false.
    /// </summary>
    [JsonPropertyName("strict")]
    public bool? Strict { get; set; }
}