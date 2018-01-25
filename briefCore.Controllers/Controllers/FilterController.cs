﻿using briefCore.Controllers.Extensions;

namespace brief.Controllers.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.OData;
    using System.Web.OData.Extensions;
    using System.Web.OData.Query;
    using System.Web.OData.Routing;
    using Extensions;
    using Models.RetrieveModels;
    using Providers;

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

            return new PageResult<BookRetrieveModel>(
                results as IEnumerable<BookRetrieveModel>,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
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
}
