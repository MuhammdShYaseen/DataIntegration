using DataIntegration.DataAccess.SyncState;
using DataIntegration.DataSource.DummyJson.DTOs;
using DataIntegration.DataSource.DummyJson;
using DataIntegration.MappingProfiles.DummyJson;
using DataIntegration.Models.Abstractions;
using DataIntegration.Models.Payloads;
using DataIntegration.Services.Orchestration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace DataIntegration.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIntegrationServices(this IServiceCollection s, IConfiguration c)
        {
            s.AddSingleton<ISyncStateStore>(new FileSyncStateStore("sync-state.json"));

            s.AddHttpClient<DummyJsonDataSource>(h => h.BaseAddress = new Uri("https://dummyjson.com"));
            s.AddSingleton<IDataSource>(sp => sp.GetRequiredService<DummyJsonDataSource>());

            s.AddSingleton<IMapper<DummyJsonProductDto, ProductPayload>, DummyJsonProductMapper>();

            s.AddHttpClient<ProductsApiClient>(h => h.BaseAddress = new Uri(c["Api:BaseUrl"]!));

            s.AddSingleton<IApiClient<ProductPayload>, ProductsApiClient>();

            s.AddSingleton<IDataSyncOrchestrator, DataSyncOrchestrator>();
            return s;
        }
    }
}