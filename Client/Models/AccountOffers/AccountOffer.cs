using System.Text.Json.Serialization;

namespace Client.Models.AccountOffers;

public class AccountOffer
{
    /// <summary>
    /// Options set for this offer entry as bit-flags.
    /// </summary>
    [JsonPropertyName("flags")]
    public uint Flags { get; set; }

    /// <summary>
    /// The exchange rate of the offer, as the ratio of the original taker_pays divided by the original taker_gets.
    /// When executing offers, the offer with the most favorable (lowest) quality is consumed first;
    /// offers with the same quality are executed from oldest to newest.
    /// </summary>
    [JsonPropertyName("quality")]
    public string Quality { get; set; }

    /// <summary>
    /// Sequence number of the transaction that created this entry. (Transaction sequence numbers are relative to accounts.)
    /// </summary>
    [JsonPropertyName("seq")]
    public uint Sequence { get; set; }

    /// <summary>
    /// The amount the account accepting the offer receives, as a String representing an amount in XRP, or a currency specification object.
    /// (See Specifying Currency Amounts)
    /// </summary>
    [JsonPropertyName("taker_gets")]
    public object TakerGets { get; set; }

    /// <summary>
    /// The amount the account accepting the offer provides, as a String representing an amount in XRP, or a currency specification object.
    /// (See Specifying Currency Amounts)
    /// </summary>
    [JsonPropertyName("taker_pays")]
    public object TakerPays { get; set; }

    /// <summary>
    /// (May be omitted) A time after which this offer is considered unfunded, as the number of seconds since the Ripple Epoch.
    /// See also: Offer Expiration.
    /// </summary>
    [JsonPropertyName("expiration")]
    public uint? Expiration { get; set; }
}