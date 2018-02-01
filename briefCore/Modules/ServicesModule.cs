﻿namespace briefCore.Modules
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using Autofac;
    using Autofac.Core;
    using brief.Controllers.Helpers;
    using brief.Controllers.Providers;
    using brief.Library.Repositories;
    using brief.Library.Services;
    using Data.Repositories;
    using Library.Helpers;
    using Library.Services;

    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var imageFormatConverter = new ImageFormatConverter();

            var baseTransformerSettings = new BaseTransformerSettings
            {
                MainTransformerFormat = (ImageFormat)imageFormatConverter.ConvertFromString("")//ConfigurationManager.AppSettings["mainFormat"])
            };

            builder.RegisterType<SeriesService>()
                .As<ISeriesService>();
            builder.RegisterType<AuthorService>()
                .As<IAuthorService>();
            builder.RegisterType<BookRepository>()
                .As<IBookRepository>();
            builder.RegisterType<EditionRepository>()
                .As<IEditionRepository>();
            builder.RegisterType<FilterService>()
                .As<IFilterService>();
            builder.RegisterType<BookService>()
                .As<IBookService>();
            builder.RegisterType<EditionService>()
                .As<IEditionService>()
                .WithParameters(new Parameter[]
                {
                    new TypedParameter(typeof(BaseTransformerSettings), baseTransformerSettings),
                    new TypedParameter(typeof(StorageSettings), new StorageSettings {StoragePath = ""})//ConfigurationManager.AppSettings["saveEditionPath"]})
                });
            builder.RegisterType<CoverService>()
                .As<ICoverService>()
                .WithParameters(new Parameter[]
                {
                    new TypedParameter(typeof(BaseTransformerSettings), baseTransformerSettings),
                    new TypedParameter(typeof(StorageSettings), new StorageSettings {StoragePath = ""})//ConfigurationManager.AppSettings["saveCoverPath"]})
                });
        }
    }
}