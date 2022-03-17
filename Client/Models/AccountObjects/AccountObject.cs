using System.Text.Json.Serialization;

namespace Client.Models.AccountObjects;

public class AccountObject
{
    [JsonPropertyName("Balance")]
    public AccountCurrency Balance { get; set; }
    [JsonPropertyName("Flags")]
    public uint Flags { get; set; }
    [JsonPropertyName("HighLimit")]
    public AccountCurrency HighLimit { get; set; }
    [JsonPropertyName("LowLimit")]
    public AccountCurrency LowLimit { get; set; }
    [JsonPropertyName("HighNode")]
    public string HighNode { get; set; }
    [JsonPropertyName("LedgerEntryType")]
    public string LedgerEntryType { get; set; }
    [JsonPropertyName("LowNode")]
    public string LowNode { get; set; }
    [JsonPropertyName("PreviousTxnID")]
    public string PreviousTxnID { get; set; }
    [JsonPropertyName("PreviousTxnLgrSeq")]
    public uint PreviousTxnLgrSeq { get; set; }
    [JsonPropertyName("index")]
    public string Index { get; set; }
}