﻿namespace briefCore.Controllers.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Providers.ServiceProviders;

    [Authorize]
    [Route("api/[controller]/[action]")]
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService ?? throw new ArgumentNullException(nameof(publisherService));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create([FromBody] PublisherModel publisher)
        {
            var result = await _publisherService.CreatePublisher(publisher);

            return result.CreateRespose(HttpStatusCode.Created, HttpStatusCode.BadRequest);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update([FromBody] PublisherModel publisher)
        {
            var result = await _publisherService.UpdatePublisher(publisher);

            return result.CreateRespose(HttpStatusCode.OK, HttpStatusCode.NoContent);
        }

        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            var result = await _publisherService.RemovePublisher(id);

            return result.CreateRespose(HttpStatusCode.OK, HttpStatusCode.NoContent);
        }
    }
}
