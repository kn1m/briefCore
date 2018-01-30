namespace briefCore.Controllers.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO.Abstractions;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using brief.Controllers.Models;
    using brief.Controllers.Providers;
    using BaseControllers;
    using Extensions;
    using Helpers.Base;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class EditionController : BaseImageUploadController
    {
        private readonly IEditionService _editionService;
        private readonly IHeaderSettings _headerSettings;

        public EditionController(IEditionService editionService, IFileSystem fileSystem, IHeaderSettings headerSettings) : base(fileSystem)
        {
            _editionService = editionService ?? throw new ArgumentNullException(nameof(editionService));
            _headerSettings = headerSettings ?? throw new ArgumentException(nameof(headerSettings));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> RetriveData(List<IFormFile> imageFiles)
            => await BaseTextRecognitionUpload(imageFiles, _editionService.RetrieveEditionDataFromImage, _editionService.StorageSettings, _headerSettings);

        [HttpPost]
        public async Task<HttpResponseMessage> Create([FromBody] EditionModel edition)
        {
            var result = await _editionService.CreateEdition(edition);

            return result.CreateRespose(HttpStatusCode.Created, HttpStatusCode.BadRequest);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update([FromBody] EditionModel edition)
        {
            var result = await _editionService.CreateEdition(edition);

            return result.CreateRespose(HttpStatusCode.OK, HttpStatusCode.NoContent);
        }

        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            var result = await _editionService.RemoveEdition(id);

            return result.CreateRespose(HttpStatusCode.OK, HttpStatusCode.NoContent);
        }
    }
}
