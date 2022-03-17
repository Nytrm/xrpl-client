using System.Text.Json.Serialization;

namespace Client.Models;

public class AccountData
{
    /// <summary>
    /// The value 0x0053, mapped to the string SignerList, indicates that this object is a SignerList object.
    /// </summary>
    [JsonPropertyName("LedgerEntryType")]
    public string LedgerEntryType { get; set; }
    /// <summary>
    /// A bit-map of Boolean flags enabled for this signer list. For more information, see SignerList Flags.
    /// </summary>
    [JsonPropertyName("Flags")]
    public uint Flags { get; set; }
    /// <summary>
    /// The identifying hash of the transaction that most recently modified this object.
    /// </summary>
    [JsonPropertyName("PreviousTxnID")]
    public string PreviousTxnID { get; set; }
    /// <summary>
    /// The index of the ledger that contains the transaction that most recently modified this object.
    /// </summary>
    [JsonPropertyName("PreviousTxnLgrSeq")]
    public uint PreviousTxnLgrSeq { get; set; }
    /// <summary>
    /// A hint indicating which page of the owner directory links to this object, in case the directory consists of multiple pages.
    /// </summary>
    [JsonPropertyName("OwnerNode")]
    public string OwnerNode { get; set; }
    /// <summary>
    /// An array of Signer Entry objects representing the parties who are part of this signer list.
    /// </summary>
    [JsonPropertyName("SignerEntries")]
    public List<SignerEntry> SignerEntries { get; set; }
    /// <summary>
    /// An ID for this signer list. Currently always set to 0.
    /// If a future amendment allows multiple signer lists for an account, this may change.
    /// </summary>
    [JsonPropertyName("SignerListID")]
    public uint SignerListID { get; set; }
    /// <summary>
    /// A target number for signer weights.
    /// To produce a valid signature for the owner of this SignerList, the signers must provide valid signatures whose weights sum to this value or more.
    /// </summary>
    [JsonPropertyName("SignerQuorum")]
    public uint SignerQuorum { get; set; }
}