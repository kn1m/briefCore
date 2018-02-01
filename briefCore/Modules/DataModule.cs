namespace briefCore.Modules
{
    using System.IO;
    using Autofac;
    using Autofac.Core;
    using brief.Data.Repositories;
    using brief.Library.Repositories;
    using brief.Library.Transformers;
    using Data.Contexts;
    using Data.Contexts.Interfaces;
    using Data.Repositories;
    using Data.Transformers;
    using Microsoft.Extensions.Configuration;

    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            
            
            //NameValueCollection myParamsCollection =
            //    (NameValueCollection)ConfigurationManager.GetSection("tesseractData");

            builder.RegisterType<TesseractTransformer>()
                .As<ITransformer<string, string>>()
                .WithParameters(new Parameter[]
                {
                    //new NamedParameter("dataPath", myParamsCollection["TrainDataPath"]),
                    //new NamedParameter("mode", myParamsCollection["EngineMode"].ConvertToEnum<EngineMode>())
                });

            var briefConnectionString = config.GetConnectionString("briefContext");//ConfigurationManager.ConnectionStrings["briefContext"].ConnectionString;

            builder.RegisterType<ApplicationDbContext>()
                .As<IApplicationDbContext>()
                .WithParameter(new NamedParameter("connectionString", briefConnectionString))
                .InstancePerLifetimeScope();

            builder.RegisterType<CoverRepository>()
                .As<ICoverRepository>()
                .WithParameter(new TypedParameter(typeof(string), briefConnectionString));
            builder.RegisterType<SeriesRepository>()
                .As<ISeriesRepository>()
                .WithParameter(new TypedParameter(typeof(string), briefConnectionString));
            builder.RegisterType<AuthorRepository>()
                .As<IAuthorRepository>()
                .WithParameter(new TypedParameter(typeof(string), briefConnectionString));

            builder.RegisterType<FilterRepository>()
                .As<IFilterRepository>();
        }
    }
}