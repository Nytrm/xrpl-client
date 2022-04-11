using System.Text.Json.Serialization;

namespace RpcClient.Models.AccountObjects;

public class AccountCurrency
{
    [JsonPropertyName("currency")]
    public string Currency { get; set; }
    [JsonPropertyName("issuer")]
    public string Issuer { get; set; }
    [JsonPropertyName("value")]
    public string Value { get; set; }
}