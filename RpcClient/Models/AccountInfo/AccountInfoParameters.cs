using System.Text.Json.Serialization;

namespace RpcClient.Models.AccountInfo;

public class AccountInfoParameters
{
    /// <summary>
    /// A unique identifier for the account, most commonly the account's Address.
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; set; }
    /// <summary>
    /// (Optional) A 20-byte hex string for the ledger version to use. (See Specifying Ledgers)
    /// </summary>
    [JsonPropertyName("ledger_hash")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LedgerHash { get; set; }
    /// <summary>
    /// (Optional) The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
    /// (See Specifying Ledgers)
    /// </summary>
    [JsonPropertyName("ledger_index")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LedgerIndex { get; set; }
    
    /// <summary>
    /// Optional) If true, and the FeeEscalation amendment is enabled, also returns stats about queued transactions associated with this account.
    /// Can only be used when querying for the data from the current open ledger.
    /// New in: rippled 0.33.0  Not available from servers in Reporting Mode.
    /// </summary>
    [JsonPropertyName("queue")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Queue { get; set; }

    /// <summary>
    /// (Optional) If true, and the MultiSign amendment is enabled, also returns any SignerList objects associated with this account.
    /// </summary>
    [JsonPropertyName("signer_lists")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SignerLists { get; set; }
    
    /// <summary>
    /// (Optional) If true, then the account field only accepts a public key or XRP Ledger address.
    /// Otherwise, account can be a secret or passphrase (not recommended). The default is false.
    /// </summary>
    [JsonPropertyName("strict")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Strict { get; set; }
}