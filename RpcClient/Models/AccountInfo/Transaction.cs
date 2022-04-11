using System.Text.Json.Serialization;

namespace RpcClient.Models.AccountInfo;

public class Transaction
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("auth_change")]
    public bool? AuthChange { get; set; }
    /// <summary>
    /// The Transaction Cost of this transaction, in drops of XRP.
    /// </summary>
    [JsonPropertyName("fee")]
    public string? Fee { get; set; }
    /// <summary>
    /// The transaction cost of this transaction, relative to the minimum cost for this type of transaction, in fee levels.
    /// </summary>
    [JsonPropertyName("fee_level")]
    public string? FeeLevel { get; set; }
    /// <summary>
    /// The maximum amount of XRP, in drops, this transaction could send or destroy.
    /// </summary>
    [JsonPropertyName("max_spend_drops")]
    public string? MaxSpendDrops { get; set; }
    /// <summary>
    /// The Sequence Number of this transaction.
    /// </summary>
    [JsonPropertyName("sec")]
    public int? Sequence { get; set; }
}