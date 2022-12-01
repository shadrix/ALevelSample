using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Services.Abstractions;
using Newtonsoft.Json;

namespace ALevelSample.Services;

public class InternalHttpClientService : IInternalHttpClientService
{
    private readonly IHttpClientFactory _clientFactory;

    public InternalHttpClientService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest content = null)
        where TRequest : class
    {
        var client = _clientFactory.CreateClient();

        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = method;

        if (content != null)
        {
            httpMessage.Content =
                new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
        }

        var result = await client.SendAsync(httpMessage);

        if (result.IsSuccessStatusCode)
        {
            var resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
            return response!;
        }

        return default(TResponse) !;
    }
}