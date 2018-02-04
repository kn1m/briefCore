namespace briefCore
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Xml;
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using Controllers.Controllers.BaseControllers;
    using Controllers.Filters;
    using Controllers.Models;
    using Controllers.Models.RetrieveModels;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Data.Contexts;
    using log4net;
    using Microsoft.AspNet.OData.Builder;
    using Microsoft.AspNet.OData.Extensions;
    using Microsoft.AspNet.OData.Formatter;
    using Microsoft.AspNetCore.Http.Features;
    using Microsoft.Net.Http.Headers;
    using Modules;
    using Swashbuckle.AspNetCore.Swagger;

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
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("log4net.config"));
            var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
            
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 300000000;
            });
            
            services.AddRouting(options => options.LowercaseUrls = true);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "brief API", Version = "v1" });
            });
            
            services.AddOData();
            
            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
                foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });
            
            services.AddMvc(config => { config.Filters.Add(new ActionLogger()); })
                .AddWebApiConventions()
                .AddApplicationPart(typeof(BaseImageUploadController).Assembly)
                .AddControllersAsServices();
                        
            var containerBuilder = new ContainerBuilder();
            
            containerBuilder.RegisterModule(new CommonModule());
            containerBuilder.RegisterModule(new DataModule(Configuration));
            containerBuilder.RegisterModule(new ServicesModule(Configuration));
            
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
            
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "brief API V1");
            });
            
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
                routes.MapWebApiRoute("default", "api/{controller}/{action}/{id?}");
                routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
            });
        }
    }
}