﻿namespace briefCore.Controllers.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Extensions;
    using Helpers.Base;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.BaseEntities;
    using Providers;
    using Providers.ServiceProviders;

    [Authorize]
    [Route("api/[controller]/[action]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IHeaderSettings _headerSettings;

        public BookController(IBookService bookService, IHeaderSettings headerSettings)
        {
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
            _headerSettings = headerSettings ?? throw new ArgumentException(nameof(headerSettings));
        }

        [HttpPost("{authorId},{bookId}")]
        public async Task<HttpResponseMessage> AddAuthorToBook(Guid authorId, Guid bookId)
        {
            var result = await _bookService.AddAuthorForBook(authorId, bookId);

            return result.CreateRespose(HttpStatusCode.OK, HttpStatusCode.NoContent);
        }

        [HttpDelete("{authorId},{bookId}")]
        public async Task<HttpResponseMessage> RemoveAuthorFromBook(Guid authorId, Guid bookId)
        {
            var result = await _bookService.RemoveAuthorFromBook(authorId, bookId);

            return result.CreateRespose(HttpStatusCode.Created, HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create([FromBody] BookModel book)
        {
            var forced = Request.RetrieveHeader("Forced", _headerSettings);

            BaseResponseMessage result;

            if (forced != null)
            {
                result = await _bookService.CreateBook(book, true);
            }
            else
            {
                result = await _bookService.CreateBook(book);
            }

            return result.CreateRespose(HttpStatusCode.Created, HttpStatusCode.BadRequest);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update([FromBody] BookModel book)
        {
            var result = await _bookService.UpdateBook(book);

            return result.CreateRespose(HttpStatusCode.OK, HttpStatusCode.NoContent);
        }

        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            var result = await _bookService.RemoveBook(id);

            return result.CreateRespose(HttpStatusCode.OK, HttpStatusCode.NoContent);
        }
    }
}