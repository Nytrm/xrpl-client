using System.Text.Json.Serialization;

namespace RpcClient.Models.AccountTransactions;

public class AccountTransactionsResult
{
    /// <summary>
    /// Unique Address identifying the related account
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; set; }
    
    /// <summary>
    /// Array of transactions matching the request's criteria, as explained below.
    /// </summary>
    [JsonPropertyName("transactions")]
    public List<Transaction> Transactions { get; set; }

    /// <summary>
    /// The ledger index of the earliest ledger actually searched for transactions.
    /// </summary>
    [JsonPropertyName("ledger_index_min")]
    public int LedgerIndexMin { get; set; }
    
    /// <summary>
    /// The ledger index of the most recent ledger actually searched for transactions.
    /// </summary>
    [JsonPropertyName("ledger_index_max")]
    public int LedgerIndexMax { get; set; }

    /// <summary>
    /// The limit value used in the request. (This may differ from the actual limit value enforced by the server.)
    /// </summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; }
    
    /// <summary>
    /// (May be omitted) Server-defined value for pagination.
    /// Pass this to the next call to resume getting results where this call left off.
    /// Omitted when there are no additional pages after this one.
    /// </summary>
    ///  TODO change from string to marker type
    [JsonPropertyName("marker")]
    public string Marker { get; set; }
    
    /// <summary>
    /// The request status
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }
    
    /// <summary>
    /// (May be omitted) If true, the information in this response comes from a validated ledger version.
    /// Otherwise, the information is subject to change.
    /// </summary>
    [JsonPropertyName("validated")]
    public bool Validated { get; set; }
}