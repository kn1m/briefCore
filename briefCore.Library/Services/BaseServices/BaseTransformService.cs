﻿namespace briefCore.Library.Services.BaseServices
{
    using System;
    using System.Drawing;
    using System.IO.Abstractions;
    using brief.Library.Services.BaseServices;
    using Helpers;
    using System.Drawing.Imaging;

    public abstract class BaseTransformService : BaseFileService
    {
        private readonly ImageFormat _mainTransformerFormat;

        protected BaseTransformService(BaseTransformerSettings settings, IFileSystem fileSystem) : base(fileSystem)
        {
            Guard.AssertNotNull(settings, nameof(settings));

            _mainTransformerFormat = settings.MainTransformerFormat;
        }

        public virtual string ConvertToAppropirateFormat(string existingFilePath, bool deleteOriginal)
        {
            var image = Image.FromFile(existingFilePath);

            if (image.RawFormat.Equals(_mainTransformerFormat))
            {
                return existingFilePath;
            }

            var newPath = existingFilePath.Substring(0, existingFilePath.LastIndexOf(".", StringComparison.Ordinal)) + "." +
                          _mainTransformerFormat;

            image.Save(newPath, _mainTransformerFormat);
            image.Dispose();

            if (deleteOriginal)
            {
                FileSystem.File.Delete(existingFilePath);
            }

            return newPath;
        }
    }
}
