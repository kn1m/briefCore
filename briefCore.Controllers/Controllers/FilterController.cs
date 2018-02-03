/*namespace briefCore.Controllers.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using brief.Controllers.Providers;
    using Extensions;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNet.OData.Query;
    using Microsoft.AspNet.OData.Routing;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Models.RetrieveModels;

    public class FilterController : ODataController
    {
        private readonly IFilterService _filterService;

        public FilterController(IFilterService filterService)
        {
            _filterService = filterService ?? throw new ArgumentNullException(nameof(filterService));
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("books({key})")]
        public SingleResult<BookRetrieveModel> Get([FromODataUri] Guid key)
        {
            IQueryable<BookRetrieveModel> result = _filterService.GetBookById(key);

            return SingleResult.Create(result);
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("books")]
        public PageResult<BookRetrieveModel> Get(ODataQueryOptions<BookRetrieveModel> options)
        {
            IQueryable results = options.ApplyTo(_filterService.GetBooks(), new ODataQuerySettings { PageSize = 5 });

            return null;
            //TODO: fix
            /*
            return new PageResult<BookRetrieveModel>(
                results as IEnumerable<BookRetrieveModel>,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
                //
        }

        [HttpGet]
        [ODataRoute("covers({key})")]
        public HttpResponseMessage GetCover([FromODataUri] Guid key)
        {
            var cover = _filterService.GetCoverById(key);

            var response = new HttpResponseMessage();

            return response.RetrieveContentFromCover(cover);
        }
    }
}*/
