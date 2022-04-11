using System.Text.Json.Serialization;

namespace RpcClient.Models.AccountTransactions;

public class Transaction
{
    /// <summary>
    /// The ledger index of the ledger version that included this transaction.
    /// </summary>
    [JsonPropertyName("ledger_index")]
    public int LedgerIndex { get; set; }

    /// <summary>
    /// If binary is True, then this is a hex string of the transaction metadata.
    /// Otherwise, the transaction metadata is included in JSON format.
    /// </summary>
    [JsonPropertyName("meta")]
    public object Meta { get; set; }
    
    /// <summary>
    /// JSON object defining the transaction
    /// </summary>
    [JsonPropertyName("tx")]
    public object Tx{ get; set; }
    /// <summary>
    /// (Binary mode only) Unique hashed String representing the transaction.
    /// </summary>
    [JsonPropertyName("tx_blob")]
    public string? Blob { get; set; }

    /// <summary>
    /// Whether or not the transaction is included in a validated ledger.
    /// Any transaction not yet in a validated ledger is subject to change.
    /// </summary>
    [JsonPropertyName("validated")]
    public bool Validated { get; set; }
}