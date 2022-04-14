using System.Text.Json.Serialization;

namespace RpcClient.Models.AccountChannel;

/// <summary>
/// https://xrpl.org/account_channels.html
/// </summary>
public class AccountChannelResult
{
    /// <summary>
    /// The address of the source/owner of the payment channels.
    /// This corresponds to the account field of the request.
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; set; }
    /// <summary>
    /// Payment channels owned by this account.
    /// </summary>
    [JsonPropertyName("channels")]
    public List<Channel> Channels { get; set; }
    /// <summary>
    /// (May be omitted) The identifying Hash of the ledger version used to generate this response.
    /// </summary>
    [JsonPropertyName("ledger_hash")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LedgerHash { get; set; }
    /// <summary>
    /// The Ledger Index of the ledger version used to generate this response.
    /// </summary>
    [JsonPropertyName("ledger_index")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? LedgerIndex { get; set; }

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
    /// (May be omitted) Server-defined value for pagination.
    /// Pass this to the next call to resume getting results where this call left off.
    /// Omitted when there are no additional pages after this one.
    /// </summary>
    ///  TODO change from string to marker type
    [JsonPropertyName("marker")]
    public object? Marker { get; set; }

    /// <summary>
    /// The request status.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }
}