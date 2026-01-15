namespace DataIntegration.Models.Abstractions
{
    public interface IApiClient<TPayload>
    {
        Task SendAsync(IReadOnlyCollection<TPayload> items, CancellationToken token = default);
    }
}