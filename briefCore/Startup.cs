namespace briefCore
{
    using Autofac;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Data.Contexts;
    using Modules;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
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

            app.UseMvc();
        }
        
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new CommonModule());
            builder.RegisterModule(new DataModule(Configuration));
            builder.RegisterModule(new ServicesModule(Configuration));
            builder.RegisterModule(new ControllersModule());
        }
    }
}