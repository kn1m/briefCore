namespace briefCore.Controllers.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using brief.Controllers.Models;
    using brief.Controllers.Providers;
    using Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Providers;

    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create([FromBody] AuthorModel author)
        {
            var result = await _authorService.CreateAuthor(author);

            return result.CreateRespose(HttpStatusCode.Created, HttpStatusCode.BadRequest);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update([FromBody] AuthorModel author)
        {
            var result = await _authorService.UpdateAuthor(author);

            return result.CreateRespose(HttpStatusCode.OK, HttpStatusCode.NoContent);
        }

        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            var result = await _authorService.RemoveAuthor(id);

            return result.CreateRespose(HttpStatusCode.OK, HttpStatusCode.NoContent);
        }
    }
}
