namespace briefCore.Modules
{
    using System;
    using Autofac;
    using Autofac.Core;
    using brief.Library.Repositories;
    using brief.Library.Transformers;
    using Data.Contexts;
    using Data.Contexts.Interfaces;
    using Data.Repositories;
    using Data.Transformers;
    using Library.Helpers;
    using Library.Repositories;
    using Microsoft.Extensions.Configuration;
    using Tesseract;

    public class DataModule : Module
    {
        private readonly IConfiguration _configuration;
        
        public DataModule(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TesseractTransformer>()
                .As<ITransformer<string, string>>()
                .WithParameters(new Parameter[]
                {
                    new NamedParameter("dataPath", _configuration["TesseractSettings:TrainDataPath"]),
                    new NamedParameter("mode", _configuration["TesseractSettings:EngineMode"].ConvertToEnum<EngineMode>())
                });

            var briefConnectionString = _configuration.GetConnectionString("briefContext");

            builder.RegisterType<ApplicationDbContext>()
                .As<IApplicationDbContext>()
                .WithParameter(new NamedParameter("connectionString", briefConnectionString))
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>()
                .WithParameter(new NamedParameter("connectionString", briefConnectionString))
                .InstancePerLifetimeScope()
                .AsSelf();

            RegisterRepositories(builder, briefConnectionString);
        }

        private void RegisterRepositories(ContainerBuilder builder, string connectionString)
        {
            builder.RegisterType<CoverRepository>()
                .As<ICoverRepository>()
                .WithParameter(new TypedParameter(typeof(string), connectionString));
            builder.RegisterType<SeriesRepository>()
                .As<ISeriesRepository>()
                .WithParameter(new TypedParameter(typeof(string), connectionString));
            builder.RegisterType<AuthorRepository>()
                .As<IAuthorRepository>()
                .WithParameter(new TypedParameter(typeof(string), connectionString));
            
            builder.RegisterType<FilterRepository>()
                .As<IFilterRepository>();
            builder.RegisterType<EditionFileRepository>()
                .As<IEditionFileRepository>();
            builder.RegisterType<DeviceRepository>()
                .As<IDeviceRepository>();
            builder.RegisterType<UserDeviceRepository>()
                .As<IUserDeviceRepository>();
        }
    }
}