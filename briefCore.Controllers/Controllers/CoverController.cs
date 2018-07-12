namespace briefCore.Controllers.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO.Abstractions;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using BaseControllers;
    using Extensions;
    using Helpers.Base;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Providers.ServiceProviders;

    [Authorize]
    [Route("api/[controller]/[action]")]
    public class CoverController : BaseImageUploadController
    {
        private readonly ICoverService _coverService;
        private readonly IHeaderSettings _headerSettings;

        public CoverController(ICoverService coverService,
                               IFileSystem fileSystem,
                               IHeaderSettings headerSettings) : base(fileSystem)
        {
            _coverService = coverService ?? throw new ArgumentNullException(nameof(coverService));
            _headerSettings = headerSettings ?? throw new ArgumentException(nameof(headerSettings));
        }

        [HttpPost("{id}")]
        public async Task<HttpResponseMessage> SaveCover(Guid id, List<IFormFile> imageFiles)
            => await BaseImageUpload(imageFiles, _coverService.SaveCover, _coverService.StorageSettings, id);

        [HttpPost]
        public async Task<HttpResponseMessage> RetrieveDataFromCover(List<IFormFile> imageFiles)
            => await BaseTextRecognitionUpload(imageFiles, _coverService.RetrieveDataFromCover, _coverService.StorageSettings, _headerSettings);

        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            var result = await _coverService.RemoveCover(id);

            return result.CreateRespose(HttpStatusCode.OK, HttpStatusCode.NoContent);
        }
    }
}
