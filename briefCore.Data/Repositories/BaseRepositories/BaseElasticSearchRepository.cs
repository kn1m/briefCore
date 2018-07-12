namespace briefCore.Data.Repositories.BaseRepositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Elasticsearch.Net;
    using JetBrains.Annotations;
    using Library.Helpers;
    using Nest;

    public class BaseElasticSearchRepository
    {
        private readonly IList<string> _nodesAddresses;
        
        public BaseElasticSearchRepository([NotNull]IList<string> nodesAddresses)
        {
            Guard.AssertNotNull(nodesAddresses, nameof(nodesAddresses));

            _nodesAddresses = nodesAddresses;
        }

        public ElasticClient GetClient()
        {
            if (_nodesAddresses.Count > 1)
            {
                var nodes = _nodesAddresses.Select(n => new Uri(n)).ToArray(); 
                
                var pool = new StaticConnectionPool(nodes);
                var poolSettings = new ConnectionSettings(pool);
                return new ElasticClient(poolSettings);
            }
            
            var node = new Uri(_nodesAddresses.First());
            var settings = new ConnectionSettings(node);
            return new ElasticClient(settings);
        }
    }
}