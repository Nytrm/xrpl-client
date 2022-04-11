using System.Net.Http.Headers;
using System.Text.Json;
using RpcClient.Options;
using Microsoft.Extensions.Options;

namespace RpcClient.Client;

using Models;
using Options;

public class RippleAccountClient
{
    private readonly HttpClient _httpClient;

    public RippleAccountClient(IOptionsMonitor<RippleOptions> rippleOptions, HttpClient httpClient)
    {
        _httpClient = httpClient;

        _httpClient.BaseAddress = new Uri(rippleOptions.CurrentValue.BaseUrl);
    }

    public async Task<T?> GetAsync<T>(UriBuilder uriBuilder, CancellationToken cancellationToken = default) where T : class
    {
        var httpResponse = await _httpClient.GetAsync(uriBuilder.ToString(), cancellationToken);

        httpResponse.EnsureSuccessStatusCode();

        return await JsonSerializer.DeserializeAsync<T>(await httpResponse.Content.ReadAsStreamAsync(cancellationToken), cancellationToken: cancellationToken);
    }
    
    public async Task<Response<T>> PostAsync<T>(object data, CancellationToken cancellationToken = default) where T : class
    {
        var request = new StringContent(JsonSerializer.Serialize(data));
        request.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var httpResponse = await _httpClient.PostAsync("", request, cancellationToken);
        
        var content = await httpResponse.Content.ReadAsStringAsync(cancellationToken);

        var response = new Response<T>();
        
        var json = JsonDocument.Parse(content);
        if (json.RootElement.TryGetProperty("result", out var result) && result.TryGetProperty("status", out var status))
        {
            response.Success = status.GetString()!.Equals("success");

            if (response.Success)
            {
                response.Result = result.Deserialize<T>()!;
            }
            else
            {
                response.Error = result.GetProperty("error").ToString();
            }
        }
        else
        {
            response.Error = "something went wrong parsing the response";
        }

        return response;
    }
}