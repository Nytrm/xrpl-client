using System.Text.Json.Serialization;

namespace Client.Models.AccountInfo;

public class QueueData
{
    /// <summary>
    /// Number of queued transactions from this address.
    /// </summary>
    [JsonPropertyName("txn_count")]
    public int TransactionCount { get; set; }

    /// <summary>
    /// (May be omitted) Whether a transaction in the queue changes this address's ways of authorizing transactions.
    /// If true, this address can queue no further transactions until that transaction has been executed or dropped from the queue.
    /// </summary>
    [JsonPropertyName("auth_change_queued")]
    public bool? AuthChangeQueued { get; set; }

    /// <summary>
    /// (May be omitted) The lowest Sequence Number among transactions queued by this address.
    /// </summary>
    [JsonPropertyName("lowest_sequence")]
    public int? LowestSequence { get; set; }

    /// <summary>
    /// (May be omitted) The highest Sequence Number among transactions queued by this address.
    /// </summary>
    [JsonPropertyName("highest_sequence")]
    public int? HighestSequence { get; set; }

    /// <summary>
    /// (May be omitted) Integer amount of drops of XRP that could be debited from this address if every transaction in the queue consumes the maximum amount of XRP possible.
    /// </summary>
    [JsonPropertyName("max_spend_drops_total")]
    public string? MaxSpendDropsTotal { get; set; }

    /// <summary>
    /// (May be omitted) Information about each queued transaction from this address.
    /// </summary>
    [JsonPropertyName("transactions")]
    public List<Transaction> Transactions { get; set; }
}