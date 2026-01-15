using DataIntegration.Models.Abstractions;
using System.Net.Http.Json;

namespace DataIntegration.DataAccess.Api
{
    public abstract class BaseApiClient<T> : IApiClient<T>
    {
        protected readonly HttpClient Client;
        private readonly string _endpoint;

        protected BaseApiClient(HttpClient client, string endpoint)
        {
            Client = client;
            _endpoint = endpoint;
        }

        public async Task SendAsync(IReadOnlyCollection<T> items, CancellationToken token = default)
        {
            if (items.Count == 0) return;
            var res = await Client.PostAsJsonAsync(_endpoint, items, token);
            if (!res.IsSuccessStatusCode)
                throw new Exception($"API error: {res.StatusCode}");
        }
    }
}