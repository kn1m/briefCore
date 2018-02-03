namespace briefCore.Controllers.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using brief.Controllers.Providers;
    using Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("api/[controller]/[action]")]
    public class SeriesController : Controller
    {
        private readonly ISeriesService _seriesService;

        public SeriesController(ISeriesService seriesService)
        {
            _seriesService = seriesService ?? throw new ArgumentNullException(nameof(seriesService));
        }

        [HttpPost("{bookId},{seriesId}")]
        public async Task<HttpResponseMessage> AddBookToSeries(Guid bookId, Guid seriesId)
        {
            var result = await _seriesService.AddBookToSeries(bookId, seriesId);

            return result.CreateRespose(HttpStatusCode.OK, HttpStatusCode.NoContent);
        }

        [HttpDelete("{bookId},{seriesId}")]
        public async Task<HttpResponseMessage> RemoveBookFromSeries(Guid bookId, Guid seriesId)
        {
            var result = await _seriesService.RemoveBookFromSeries(bookId, seriesId);

            return result.CreateRespose(HttpStatusCode.Created, HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create([FromBody] SeriesModel series)
        {
            var result = await _seriesService.CreateSeries(series);

            return result.CreateRespose(HttpStatusCode.Created, HttpStatusCode.BadRequest);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update([FromBody] SeriesModel series)
        {
            var result = await _seriesService.UpdateSeries(series);

            return result.CreateRespose(HttpStatusCode.OK, HttpStatusCode.NoContent);
        }

        [HttpDelete("{id},{removeBooks}")]
        public async Task<HttpResponseMessage> Delete(Guid id, bool removeBooks)
        {
            var result = await _seriesService.RemoveSeries(id, removeBooks);

            return result.CreateRespose(HttpStatusCode.OK, HttpStatusCode.NoContent);
        }
    }
}
