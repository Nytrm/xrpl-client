using System.Text.Json.Serialization;

namespace RpcClient.Models.AccountOffers;

public class AccountOffersResult
{
    /// <summary>
    /// Unique Address of the account this request corresponds to
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; set; }
    /// <summary>
    /// Array of objects, where each object represents an offer made by this account that is outstanding as of the requested ledger version.
    /// If the number of offers is large, only returns up to limit at a time.
    /// </summary>
    [JsonPropertyName("offers")]
    public List<AccountOffer> Offers { get; set; }
    /// <summary>
    /// (May be omitted) If true, the information in this response comes from a validated ledger version.
    /// Otherwise, the information is subject to change.
    /// </summary>
    [JsonPropertyName("validated")]
    public bool Validated { get; set; }
    /// <summary>
    /// (Omitted if ledger_hash or ledger_index provided)
    /// The ledger index of the current in-progress ledger version, which was used when retrieving this data.
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
    ///  TODO change from string to marker type
    [JsonPropertyName("marker")]
    public object? Marker { get; set; }
    /// <summary>
    /// The request status
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }
}