using System.Text.Json.Serialization;

namespace RpcClient.Models.AccountLines;

public class AccountLinesResult
{
    /// <summary>
    /// Unique Address of the account this request corresponds to.
    /// This is the "perspective account" for purpose of the trust lines.
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; set; }
    /// <summary>
    /// Array of trust line objects, as described below.
    /// If the number of trust lines is large, only returns up to the limit at a time.
    /// </summary>
    [JsonPropertyName("lines")]
    public List<TrustLine> Lines { get; set; }
    /// <summary>
    /// (Omitted if ledger_index is provided instead)
    /// The ledger index of the current in-progress ledger, which was used when retrieving this information.
    /// </summary>
    [JsonPropertyName("ledger_current_index")]
    public int? LedgerCurrentIndex { get; set; }
    /// <summary>
    /// (Omitted if ledger_current_index is provided instead)
    /// The ledger index of the ledger version used when retrieving this information.
    /// The information does not contain any changes from ledger versions newer than this one.
    /// </summary>
    [JsonPropertyName("ledger_index")]
    public int? LedgerIndex { get; set; }
    /// <summary>
    /// (May be omitted) The identifying Hash of the ledger version used to generate this response.
    /// </summary>
    [JsonPropertyName("ledger_hash")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LedgerHash { get; set; }
    /// <summary>
    /// (May be omitted) Server-defined value for pagination.
    /// Pass this to the next call to resume getting results where this call left off.
    /// Omitted when there are no additional pages after this one.
    /// </summary>
    [JsonPropertyName("marker")]
    public object? Marker { get; set; }
    /// <summary>
    /// The request status
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }
}