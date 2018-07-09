namespace briefCore.Modules
{
    using System.Collections.Generic;
    using System.IO.Abstractions;
    using Autofac;
    using AutoMapper;
    using Controllers.Helpers;
    using Controllers.Helpers.Base;
    using Library.Entities.Profiles;

    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(typeof(BookProfile).Assembly);
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>();

            builder.RegisterType<FileSystem>()
                .As<IFileSystem>();
            
            RegisterControllerDependencies(builder);
        }

        private void RegisterControllerDependencies(ContainerBuilder builder)
        {
            var recognitionLanguagesSettings = new HeaderSettings
            {
                AcceptableValuesForHeader =
                    new Dictionary<string, string[]>
                    {
                        { "Target-Language", new[] { "ukr", "rus", "eng"} }
                    }
            };
            
            builder.Register(h => recognitionLanguagesSettings)
                .As<IHeaderSettings>()
                .InstancePerLifetimeScope();
        }
    }
}