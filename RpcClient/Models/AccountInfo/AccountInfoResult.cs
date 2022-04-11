using System.Text.Json.Serialization;

namespace RpcClient.Models.AccountInfo;

/// <summary>
/// The currencies that an account can send or receive are defined based on a check of its trust lines.
/// If an account has a trust line for a currency and enough room to increase its balance, it can receive that currency.
/// If the trust line's balance can go down, the account can send that currency.
/// This method doesn't check whether the trust line is frozen or authorized.
/// </summary>
public class AccountInfoResult
{
    /// <summary>
    /// The AccountRoot ledger object with this account's information, as stored in the ledger.
    /// </summary>
    [JsonPropertyName("account_data")]
    public AccountData AccountData { get; set; }
    /// <summary>
    /// (Omitted unless the request specified signer_lists and at least one SignerList is associated with the account.)
    /// Array of SignerList ledger objects associated with this account for Multi-Signing.
    /// Since an account can own at most one SignerList, this array must have exactly one member if it is present.
    /// </summary>
    [JsonPropertyName("signer_lists")]
    public List<SignerList> SignerLists { get; set; }
    /// <summary>
    /// (Omitted if ledger_index is provided instead)
    /// The ledger index of the current in-progress ledger, which was used when retrieving this information.
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
    /// (Omitted unless queue specified as true and querying the current open ledger.)
    /// Information about queued transactions sent by this account.
    /// This information describes the state of the local rippled server, which may be different from other servers in the peer-to-peer XRP Ledger network.
    /// Some fields may be omitted because the values are calculated "lazily" by the queuing mechanism.
    /// </summary>
    [JsonPropertyName("queue_data")]
    public QueueData QueueData { get; set; }
    /// <summary>
    /// If true, this data comes from a validated ledger.
    /// </summary>
    [JsonPropertyName("validated")]
    public bool Validated { get; set; }

    /// <summary>
    /// The request status.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }
}