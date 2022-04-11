using System.Text.Json.Serialization;

namespace RpcClient.Models.AccountObjects;

public class AccountObjectsParameters
{
    /// <summary>
    /// A unique identifier for the account, most commonly the account's address.
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; set; }
    /// <summary>
    /// (Optional) If included, filter results to include only this type of ledger object.
    /// The valid types are: check, deposit_preauth, escrow, offer, payment_channel, signer_list, ticket, and state (trust line)
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    /// <summary>
    /// (Optional) If true, the response only includes objects that would block this account from being deleted. The default is false.
    /// </summary>
    [JsonPropertyName("deletion_blockers_only")]
    public bool? DeletionBlockersOnly { get; set; }
    /// <summary>
    /// (Optional) A 20-byte hex string for the ledger version to use. (See Specifying Ledgers)
    /// </summary>
    [JsonPropertyName("ledger_hashes")]
    public string LedgerHashes { get; set; }
    /// <summary>
    /// (Optional) The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically. (See Specifying Ledgers)
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
    ///  TODO change from string to marker type
    [JsonPropertyName("marker")]
    public string? Marker { get; set; }
}