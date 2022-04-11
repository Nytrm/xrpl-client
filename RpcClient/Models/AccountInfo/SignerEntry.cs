namespace RpcClient.Models.AccountInfo;

using System.Text.Json.Serialization;

public class SignerEntry
{
    /// <summary>
    /// An XRP Ledger address whose signature contributes to the multi-signature.
    /// It does not need to be a funded address in the ledger.
    /// </summary>
    [JsonPropertyName("Account")]
    public string Account { get; set; }
    /// <summary>
    /// The weight of a signature from this signer.
    /// A multi-signature is only valid if the sum weight of the signatures provided meets or exceeds the signer list's SignerQuorum value.
    /// </summary>
    [JsonPropertyName("SignerWeight")]
    public uint SignerWeight { get; set; }
}