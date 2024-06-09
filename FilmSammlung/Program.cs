// See https://aka.ms/new-console-template for more information
using FilmSammlung;
using Serilog;

public class Program
{
    public static void Main(string[] args)
    {
        ConfigLogging();

        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureLogging(logbuilder =>
        {
            logbuilder.ClearProviders();
            logbuilder.AddConsole();
            logbuilder.AddTraceSource("Information, ActivityTracing");
        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
            
        })
        .UseSerilog();

    static void ConfigLogging()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsetting.logging.json")
            .Build();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder)
            .CreateLogger();
    }
}