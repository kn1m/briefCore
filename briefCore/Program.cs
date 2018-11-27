namespace briefCore
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Autofac.Extensions.DependencyInjection;

    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        private static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services.AddAutofac())
                .UseStartup<Startup>()
                .Build();
    }
}