namespace briefCore
{
    using System;
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using brief.Controllers.Models;
    using brief.Controllers.Models.RetrieveModels;
    using Controllers.Controllers.BaseControllers;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Data.Contexts;
    using Microsoft.AspNet.OData.Builder;
    using Microsoft.AspNet.OData.Extensions;
    using Microsoft.AspNetCore.Http.Features;
    using Modules;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 100000000;
            });
            
            services.AddOData();
            
            services.AddMvc().AddApplicationPart(typeof(BaseImageUploadController).Assembly)
                .AddControllersAsServices();
            
            var containerBuilder = new ContainerBuilder();
            
            containerBuilder.RegisterModule(new CommonModule());
            containerBuilder.RegisterModule(new DataModule(Configuration));
            containerBuilder.RegisterModule(new ServicesModule(Configuration));
            containerBuilder.RegisterModule(new ControllersModule());
            
            containerBuilder.Populate(services);
            
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            using (var client = new ApplicationDbContext(Configuration.GetConnectionString("briefContext")))
            {
                client.Database.EnsureCreated();
            }

            var builder = new ODataConventionModelBuilder(app.ApplicationServices);
            builder.EnableLowerCamelCase();
            builder.EntitySet<BookRetrieveModel>("books");
            builder.EntitySet<EditionModel>("editions");
            builder.EntitySet<CoverModel>("covers");
            
            app.UseMvc(routes =>
            {
                //routes.MapRoute("default_route", "api/[controller]/{action}/{id?}");
                routes.MapODataServiceRoute("odata", null, builder.GetEdmModel());
            });
        }
        
        /*public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new CommonModule());
            builder.RegisterModule(new DataModule(Configuration));
            builder.RegisterModule(new ServicesModule(Configuration));
            builder.RegisterModule(new ControllersModule());
        }*/
    }
}