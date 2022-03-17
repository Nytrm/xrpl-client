using System.Text.Json.Serialization;

namespace Client.Models.AccountChannel;

public class Parameter : IRequestParameters
{
    /// <summary>
    /// The unique identifier of an account, typically the account's Address.
    /// The request returns channels where this account is the channel's owner/source.
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; set; }
    /// <summary>
    /// (Optional) The unique identifier of an account, typically the account's Address.
    /// If provided, filter results to payment channels whose destination is this account.
    /// </summary>
    [JsonPropertyName("destination_account")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DestinationAccount { get; set; }
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
    /// (Optional) Limit the number of transactions to retrieve.
    /// Cannot be less than 10 or more than 400. The default is 200.
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