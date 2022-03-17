using System.Text.Json.Serialization;

namespace Client.Models.AccountCurrencies;

public class Parameters : IRequestParameters
{
    /// <summary>
    /// A unique identifier for the account, most commonly the account's Address.
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; set; }
    /// <summary>
    /// (Optional) A 20-byte hex string for the ledger version to use. (See Specifying Ledgers)
    /// </summary>
    [JsonPropertyName("command")]
    public string Command { get; set; }
    /// <summary>
    /// (Optional) The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically. (See Specifying Ledgers)
    /// </summary>
    [JsonPropertyName("ledger_index")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LedgerIndex { get; set; }
    /// <summary>
    /// (Optional) A 20-byte hex string for the ledger version to use. (See Specifying Ledgers)
    /// </summary>
    [JsonPropertyName("ledger_hash")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LedgerHash { get; set; }
    /// <summary>
    /// (Optional) If true, then the account field only accepts a public key or XRP Ledger address.
    /// Otherwise, account can be a secret or passphrase (not recommended). The default is false.
    /// The following field is deprecated and should not be provided: account_index.
    /// </summary>
    [JsonPropertyName("strict")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Strict { get; set; }
}