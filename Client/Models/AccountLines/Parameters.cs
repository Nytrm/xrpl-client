using System.Text.Json.Serialization;

namespace Client.Models.AccountLines;

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
    /// (Optional) The Address of a second account. If provided, show only lines of trust connecting the two accounts.
    /// </summary>
    [JsonPropertyName("peer")]
    public string? Peer { get; set; }
    
    /// <summary>
    /// (Optional, default varies) Limit the number of trust lines to retrieve.
    /// The server is not required to honor this value. Must be within the inclusive range 10 to 400.
    /// </summary>
    [JsonPropertyName("limit")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Limit { get; set; }

    /// <summary>
    /// (Optional) Value from a previous paginated response. Resume retrieving data where that response left off.
    /// </summary>
    ///  TODO change from string to market type
    [JsonPropertyName("market")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Marker { get; set; }
}