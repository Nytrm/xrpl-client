using System.Text.Json.Serialization;

namespace RpcClient.Models.AccountObjects;

public class AccountObjectsResult
{
    /// <summary>
    /// Unique Address of the account this request corresponds to
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; set; }
    /// <summary>
    /// Array of objects owned by this account. Each object is in its raw ledger format.
    /// </summary>
    [JsonPropertyName("account_objects")]
    public List<AccountObject> AccountObjects { get; set; }
    /// <summary>
    /// (May be omitted) If true, the information in this response comes from a validated ledger version.
    /// Otherwise, the information is subject to change.
    /// </summary>
    [JsonPropertyName("validated")]
    public bool Validated { get; set; }
    /// <summary>
    /// (May be omitted) The limit to how many channel objects were actually returned by this request.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }
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
    ///  TODO change from string to marker type
    [JsonPropertyName("marker")]
    public string? Marker { get; set; }
    /// <summary>
    /// The request status
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }
}