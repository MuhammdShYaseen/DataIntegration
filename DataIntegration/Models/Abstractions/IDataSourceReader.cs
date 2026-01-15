namespace DataIntegration.Models.Abstractions
{
    public interface IDataSourceReader<TEntity>
    {
        Task<IReadOnlyList<TEntity>> ReadPageAsync(int page, int pageSize);
    }
}