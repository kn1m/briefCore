namespace briefCore.Data.Repositories.Interfaces
{
    using System.Threading.Tasks;
    using Nest;

    public interface IElasticRepository
    {
        Task<IndexResponse> Index<TEntity>(ElasticClient client,
            TEntity entity,
            string index) where TEntity : class;
    }
}