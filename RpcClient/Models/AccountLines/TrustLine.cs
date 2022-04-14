using System.Text.Json.Serialization;

namespace RpcClient.Models.AccountLines;

public class TrustLine
{
    /// <summary>
    /// The unique Address of the counterparty to this trust line.
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; set; }
    /// <summary>
    /// Representation of the numeric balance currently held against this line.
    /// A positive balance means that the perspective account holds value;
    /// a negative balance means that the perspective account owes value.
    /// </summary>
    [JsonPropertyName("balance")]
    public string Balance { get; set; }
    
    [JsonIgnore]
    public decimal BalanceAsNumber => decimal.Parse(Balance);
    /// <summary>
    /// A Currency Code identifying what currency this trust line can hold.
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; }
    /// <summary>
    /// The maximum amount of the given currency that this account is willing to owe the peer account
    /// </summary>
    [JsonPropertyName("limit")]
    public string Limit { get; set; }

    /// <summary>
    /// The maximum amount of currency that the counterparty account is willing to owe the perspective account
    /// </summary>
    [JsonPropertyName("limit_peer")]
    public string LimitPeer { get; set; }
    /// <summary>
    /// Rate at which the account values incoming balances on this trust line, as a ratio of this value per 1 billion units.
    /// (For example, a value of 500 million represents a 0.5:1 ratio.) As a special case, 0 is treated as a 1:1 ratio.
    /// </summary>
    [JsonPropertyName("quality_in")]
    public uint QualityIn { get; set; }
    /// <summary>
    /// Rate at which the account values outgoing balances on this trust line, as a ratio of this value per 1 billion units.
    /// (For example, a value of 500 million represents a 0.5:1 ratio.) As a special case, 0 is treated as a 1:1 ratio.
    /// </summary>
    [JsonPropertyName("quality_out")]
    public uint QualityOut { get; set; }
    /// <summary>
    /// (May be omitted) If true, this account has enabled the No Ripple flag for this trust line.
    /// If present and false, this account has disabled the No Ripple flag, but, because the account also has the Default Ripple flag disabled, that is not considered the default state.
    /// If omitted, the account has the No Ripple flag disabled for this trust line and Default Ripple enabled.
    /// Updated in: rippled 1.7.0 
    /// </summary>
    [JsonPropertyName("no_ripple")]
    public bool? NoRipple { get; set; }
    /// <summary>
    /// (May be omitted) If true, the peer account has enabled the No Ripple flag for this trust line.
    /// If present and false, this account has disabled the No Ripple flag, but, because the account also has the Default Ripple flag disabled, that is not considered the default state.
    /// If omitted, the account has the No Ripple flag disabled for this trust line and Default Ripple enabled.
    /// </summary>
    [JsonPropertyName("no_ripple_peer")]
    public bool? NoRipplePeer { get; set; }
    /// <summary>
    /// (May be omitted) If true, this account has authorized this trust line. The default is false.
    /// </summary>
    [JsonPropertyName("authorized")]
    public bool? Authorized { get; set; }
    /// <summary>
    /// (May be omitted) If true, the peer account has authorized this trust line. The default is false.
    /// </summary>
    [JsonPropertyName("peer_authorized")]
    public bool? PeerAuthorized { get; set; }
    /// <summary>
    /// (May be omitted) If true, this account has frozen this trust line. The default is false.
    /// </summary>
    [JsonPropertyName("freeze")]
    public bool? Freeze { get; set; }
    /// <summary>
    /// (May be omitted) If true, the peer account has frozen this trust line. The default is false.
    /// </summary>
    [JsonPropertyName("freeze_peer")]
    public bool? FreezePeer { get; set; }
}