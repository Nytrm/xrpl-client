using System.Text.Json.Serialization;

namespace Client.Models.AccountTransactions;

public class Parameters : IRequestParameters
{
    /// <summary>
    /// A unique identifier for the account, most commonly the account's address.
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; set; }
    /// <summary>
    /// (Optional) Use to specify the most recent ledger to include transactions from.
    /// A value of -1 instructs the server to use the most recent validated ledger version available.
    /// </summary>
    [JsonPropertyName("ledger_index_max")]
    public int? LedgerIndexMax { get; set; }
    /// <summary>
    /// (Optional) Use to specify the earliest ledger to include transactions from.
    /// A value of -1 instructs the server to use the earliest validated ledger version available.
    /// </summary>
    [JsonPropertyName("ledger_index_min")]
    public int? LedgerIndexMin { get; set; }
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
    /// (Optional) Defaults to false. If set to true, returns transactions as hex strings instead of JSON.
    /// </summary>
    [JsonPropertyName("binary")]
    public bool? Binary { get; set; }
    /// <summary>
    /// (Optional) Defaults to false. If set to true, returns values indexed with the oldest ledger first.
    /// Otherwise, the results are indexed with the newest ledger first.
    /// (Each page of results may not be internally ordered, but the pages are overall ordered.)
    /// </summary>
    [JsonPropertyName("forward")]
    public bool? Forward { get; set; }
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
    public string? Marker { get; set; }
}