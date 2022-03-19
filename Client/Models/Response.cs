using System.Text.Json.Serialization;

namespace Client.Models;

public class Response
{
    /// <summary>
    /// The response id.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    

    /// <summary>
    /// The request type.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// The response result
    /// </summary>
    [JsonPropertyName("result")]
    public List<IResponseResult> Result { get; set; }
}