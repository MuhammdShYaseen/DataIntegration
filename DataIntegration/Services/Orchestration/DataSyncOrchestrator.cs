using DataIntegration.DataSource.DummyJson.DTOs;
using DataIntegration.Models.Abstractions;
using DataIntegration.Models.Payloads;
using Microsoft.Extensions.DependencyInjection;
namespace DataIntegration.Services.Orchestration
{
    public class DataSyncOrchestrator : IDataSyncOrchestrator
    {
        private readonly IDataSource _source;
        private readonly IServiceProvider _sp;
        private readonly ISyncStateStore _state;
        private const int PageSize = 50;

        public DataSyncOrchestrator(IDataSource s, IServiceProvider sp, ISyncStateStore st)
        {
            _source = s; 
            _sp = sp;
            _state = st;
        }

        public async Task RunAsync(CancellationToken token = default)
        {
            await Sync<DummyJsonProductDto, ProductPayload>("Products", token);
        }

        private async Task Sync<TSrc, TPay>(string name, CancellationToken token)
        {
            if (!_source.Supports<TSrc>()) return;

            var reader = (IDataSourceReader<TSrc>)_source;
            var mapper = _sp.GetRequiredService<IMapper<TSrc, TPay>>();
            var api = _sp.GetRequiredService<IApiClient<TPay>>();
            var last = _state.GetLastSuccessfulSync(name);

            var page = 1;
            while (true)
            {
                var data = await reader.ReadPageAsync(page++, PageSize);
                if (data.Count == 0) break;

                var changed = last == null ? data : data.Where(d => ((dynamic)d!).LastModified > last);
                await api.SendAsync(changed.Select(mapper.Map).ToList(), token);
            }

            await _state.SaveLastSuccessfulSyncAsync(name, DateTime.UtcNow);
        }
    }
}