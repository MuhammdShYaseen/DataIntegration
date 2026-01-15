using DataIntegration.DataSource.DummyJson.DTOs;
using DataIntegration.Models.Abstractions;
using System.Net.Http.Json;

namespace DataIntegration.DataSource.DummyJson
{
    public class DummyJsonDataSource : IDataSource, IDataSourceReader<DummyJsonProductDto>
    {
        private readonly HttpClient _http;

        public DummyJsonDataSource(HttpClient http) => _http = http;

        public bool Supports<TEntity>() => this is IDataSourceReader<TEntity>;

        public async Task<IReadOnlyList<DummyJsonProductDto>> ReadPageAsync(int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;
            var res = await _http.GetFromJsonAsync<Response>($"/products?limit={pageSize}&skip={skip}");
            return res?.Products ?? [];
        }



        private class Response
        {
            public List<DummyJsonProductDto> Products { get; set; } = new();
        }
    }
}