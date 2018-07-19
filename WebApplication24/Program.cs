namespace WebApplication24
{
    using System.IO;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).UseKestrel().UseContentRoot(Directory.GetCurrentDirectory()).UseIISIntegration().UseStartup<Startup>().UseApplicationInsights().Build().Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).ConfigureAppConfiguration(
                                                                                (context, builder) =>
                                                                                {
                                                                                    var environment = context.HostingEnvironment;
                                                                                    var pathOfCommonSettingsFile = Path.Combine(environment.ContentRootPath, "..", "Common");
                                                                                    builder.AddJsonFile("appSettings.json", true)
                                                                                           .AddJsonFile(Path.Combine(pathOfCommonSettingsFile, "CommonSettings.json"), true);
                                                                                    builder.AddEnvironmentVariables();
                                                                                }).UseStartup<Startup>();
        }
    }
}
