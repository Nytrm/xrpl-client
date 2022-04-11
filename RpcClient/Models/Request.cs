using System.Text.Json.Serialization;

namespace RpcClient.Models;

public class Request
{
    [JsonPropertyName("method")]
    public string Method { get; set; }

    [JsonPropertyName("params")]
    public List<object> Parameters { get; set; }
}