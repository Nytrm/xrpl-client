using System.Text.Json.Serialization;

namespace Client.Models;

public class Request
{
    [JsonPropertyName("method")]
    public string Method { get; set; }

    [JsonPropertyName("params")]
    public IRequestParameters Parameters { get; set; }
}