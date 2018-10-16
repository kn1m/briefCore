namespace briefCore.Data.Repositories.BaseRepositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Elasticsearch.Net;
    using Interfaces;
    using JetBrains.Annotations;
    using Library.Helpers;
    using Nest;

    public class ElasticSearchRepository : IElasticRepository
    {
        private const byte MinimunNodesAmout = 1;
        private readonly IList<string> _nodesAddresses;
        
        public ElasticSearchRepository([NotNull]IList<string> nodesAddresses)
        {
            Guard.AssertNotNull(nodesAddresses, nameof(nodesAddresses));

            _nodesAddresses = nodesAddresses;
        }

        public ElasticClient GetClient()
        {
            if (_nodesAddresses.Count > MinimunNodesAmout)
            {
                var nodes = _nodesAddresses
                    .Select(n => new Uri(n))
                    .ToArray(); 
                
                var pool = new StaticConnectionPool(nodes);
                var poolSettings = new ConnectionSettings(pool);
                
                return new ElasticClient(poolSettings);
            }
            
            var node = new Uri(_nodesAddresses.First());
            var settings = new ConnectionSettings(node);
            return new ElasticClient(settings);
        }

        public async Task<IndexResponse> Index<TEntity>(ElasticClient client, 
                                                        TEntity entity,
                                                        string index) where TEntity : class
        
            => await client.IndexAsync(entity, idx => idx.Index(index)) as IndexResponse;

        public async Task<TEntity> GetDocument<TEntity>(ElasticClient client, 
                                                        Guid id,
                                                        string index) where TEntity : class 
        {
            var response =  await client.GetAsync<TEntity>(id, idx => idx.Index(index));
            return response.Source;
        }

        public async Task DeleteById<TEntity>(ElasticClient client,
                                              Guid id,
                                              IndexName index,
                                              TypeName type) where TEntity : class
        
            => await client.DeleteAsync(new DeleteRequest(index, type, new Id(id)));
    }
}