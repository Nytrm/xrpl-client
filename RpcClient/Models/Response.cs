namespace RpcClient.Models;

using System.Text.Json.Serialization;

public class Response<T>
{
    [JsonPropertyName("error")]
    [JsonIgnore]
    public string? Error { get; set; }
    [JsonIgnore]
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    [JsonPropertyName("result")]
    public T Result { get; set; }
}