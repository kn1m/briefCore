namespace briefCore.Modules
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using Autofac;
    using Autofac.Core;
    using Controllers.Helpers;
    using Controllers.Providers.ServiceProviders;
    using Data.Repositories;
    using Library.Helpers;
    using Library.Repositories;
    using Library.Services;
    using Microsoft.Extensions.Configuration;

    public class ServicesModule : Module
    {
        private readonly IConfiguration _configuration;
        
        public ServicesModule(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            var imageFormatConverter = new ImageFormatConverter();

            var baseTransformerSettings = new BaseTransformerSettings
            {
                MainTransformerFormat = (ImageFormat)imageFormatConverter
                    .ConvertFromString(_configuration["FileProcessing:TargetTransformerFormat"])
            };

            builder.RegisterType<DeviceService>()
                .As<IDeviceService>();
            builder.RegisterType<SeriesService>()
                .As<ISeriesService>();
            builder.RegisterType<AuthorService>()
                .As<IAuthorService>();
            builder.RegisterType<BookEntityFrameworkRepository>()
                .As<IBookRepository>();
            builder.RegisterType<EditionEntityFrameworkRepository>()
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
                    new TypedParameter(typeof(StorageSettings), new StorageSettings
                    {
                        StoragePath = _configuration["FileProcessing:SaveEditionPath"]
                    })
                });
            builder.RegisterType<CoverService>()
                .As<ICoverService>()
                .WithParameters(new Parameter[]
                {
                    new TypedParameter(typeof(BaseTransformerSettings), baseTransformerSettings),
                    new TypedParameter(typeof(StorageSettings), new StorageSettings
                    {
                        StoragePath = _configuration["FileProcessing:SaveCoverPath"]
                    })
                });
        }
    }
}