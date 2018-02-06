namespace briefCore.Controllers.Controllers.BaseControllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Abstractions;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Extensions;
    using Helpers;
    using Helpers.Base;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.BaseEntities;

    public abstract class BaseImageUploadController : Controller
    {
        private readonly IFileSystem _fileSystem;

        protected BaseImageUploadController(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        }

        protected virtual async Task<HttpResponseMessage> BaseTextRecognitionUpload<TData>(List<IFormFile> imageFiles,
                                                                                           Func<ImageModel, Task<TData>> strategy, 
                                                                                           StorageSettings storageSettings,
                                                                                           IHeaderSettings headerSettings) 
            where TData : IRecognizable 
        {
            
            if(Request.GetMultipartBoundary() == null)
            {
                return new HttpResponseMessage { StatusCode = HttpStatusCode.UnsupportedMediaType };
            }
            
            var languageToProccess = Request.RetrieveHeader("Target-Language", headerSettings);

            if (languageToProccess == null)
            {
                return new HttpResponseMessage{ StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = "Specify appropriate target language."};
            }

            var clientFolderId = Guid.NewGuid();
            string currentProviderPath = _fileSystem.Path.Combine(storageSettings.StoragePath, clientFolderId.ToString());

            _fileSystem.Directory.CreateDirectory(currentProviderPath);

            try
            {
                List<string> files = new List<string>();
                var dataTasks = new List<Task<TData>>();

                foreach (var formFile in imageFiles)
                {
                    if (formFile.Length > 0)
                    {
                        using (var stream = new FileStream(_fileSystem.Path.Combine(currentProviderPath, formFile.FileName), FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                    
                    files.Add(_fileSystem.Path.GetFileName(formFile.FileName));

                    var imageToSave = new ImageModel
                    {
                        Path = _fileSystem.Path.Combine(currentProviderPath, formFile.FileName),
                        TargetLanguage = languageToProccess
                    };

                    dataTasks.Add(strategy.Invoke(imageToSave));
                }
                
                var results = await Task.WhenAll(dataTasks);

                _fileSystem.Directory.Delete(currentProviderPath);

                var resultingDict = Enumerable.Range(0, results.Length).ToDictionary(i => files[i], i => results[i].RawData);
                
                return new HttpResponseMessage{ StatusCode = HttpStatusCode.OK, Content = new StringContent(resultingDict.GetString()) } ;
            }
            catch (Exception e)
            {
                return new HttpResponseMessage{ StatusCode = HttpStatusCode.InternalServerError, ReasonPhrase = e.Message } ;
            }
        }

        protected virtual async Task<HttpResponseMessage> BaseImageUpload<TData>(List<IFormFile> imageFiles,
                                                                                 Func<ImageModel, Task<TData>> strategy,
                                                                                 StorageSettings storageSettings,
                                                                                 Guid targetId)
            where TData : BaseResponseMessage
        {
            if (targetId == Guid.Empty)
            {
                return new HttpResponseMessage{ StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = "Target id should be provided."};
            }

            if(Request.GetMultipartBoundary() == null)
            {
                return new HttpResponseMessage { StatusCode = HttpStatusCode.UnsupportedMediaType };
            }

            if (imageFiles.Count != 1)
            {
                return new HttpResponseMessage{StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = $"Single-file upload is only allowed. But {imageFiles.Count} files detected."};
            }

            try
            {
                var newFilename = Guid.NewGuid() + "_" + _fileSystem.Path.GetFileName(imageFiles.First().FileName);
                string newAbsolutePath = _fileSystem.Path.Combine(storageSettings.StoragePath, newFilename);

                using (var stream = new FileStream(storageSettings.StoragePath, FileMode.Create))
                {
                    await imageFiles.First().CopyToAsync(stream);
                }
                
                _fileSystem.File.Move(imageFiles.First().FileName, newAbsolutePath);

                var imageToSave = new ImageModel
                {
                    TargetId = targetId,
                    Path = newAbsolutePath
                };

                var result = await strategy.Invoke(imageToSave);

                return result.CreateRespose(HttpStatusCode.Created, HttpStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                return new HttpResponseMessage{StatusCode = HttpStatusCode.InternalServerError, ReasonPhrase = e.Message};
            }
        }
    }
}
