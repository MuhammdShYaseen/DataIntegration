namespace DataIntegration.Models.Abstractions
{
    public interface IDataSource
    {
        bool Supports<TEntity>();
    }
}
