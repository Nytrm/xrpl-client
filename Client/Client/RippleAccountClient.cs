using System.Net.Http.Headers;
using System.Text.Json;
using Client.Models;
using Client.Options;
using Microsoft.Extensions.Options;

namespace Client.Client;

public class RippleAccountClient
{
    private readonly HttpClient _httpClient;

    public RippleAccountClient(IOptionsMonitor<RippleOptions> rippleOptions, HttpClient httpClient)
    {
        _httpClient = httpClient;

        _httpClient.BaseAddress = new Uri(rippleOptions.CurrentValue.BaseUrl);
    }

    public async Task<T?> GetAsync<T>(UriBuilder uriBuilder, CancellationToken cancellationToken = default) where T : IResponseResult
    {
        var httpResponse = await _httpClient.GetAsync(uriBuilder.ToString(), cancellationToken);

        httpResponse.EnsureSuccessStatusCode();

        return await JsonSerializer.DeserializeAsync<T>(await httpResponse.Content.ReadAsStreamAsync(cancellationToken), cancellationToken: cancellationToken);
    }
    
    public async Task<T?> PostAsync<T>(object data, CancellationToken cancellationToken = default) where T : IResponseResult
    {
        var content = new ByteArrayContent(JsonSerializer.SerializeToUtf8Bytes(data));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var httpResponse = await _httpClient.PostAsync("",content, cancellationToken);

        httpResponse.EnsureSuccessStatusCode();

        return await JsonSerializer.DeserializeAsync<T>(await httpResponse.Content.ReadAsStreamAsync(cancellationToken), cancellationToken: cancellationToken);
    }
}