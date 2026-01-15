using DataIntegration.Models.Abstractions;
using System.Text.Json;

namespace DataIntegration.DataAccess.SyncState
{
    public class FileSyncStateStore : ISyncStateStore
    {
        private readonly string _path;
        private readonly Dictionary<string, DateTime> _state;

        public FileSyncStateStore(string path)
        {
            _path = path;
            _state = File.Exists(path)
                ? JsonSerializer.Deserialize<Dictionary<string, DateTime>>(File.ReadAllText(path))!
                : new();
        }

        public DateTime? GetLastSuccessfulSync(string entity)
            => _state.TryGetValue(entity, out var t) ? t : null;

        public async Task SaveLastSuccessfulSyncAsync(string entity, DateTime utc)
        {
            _state[entity] = utc;
            var json = JsonSerializer.Serialize(_state, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_path, json);
        }
    }
}