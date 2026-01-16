namespace DataIntegration.Services.Orchestration
{ 
    public interface IDataSyncOrchestrator
    {
        Task RunAsync(CancellationToken token = default);
    }
}