using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using Microsoft.OpenApi.Models;
using System.Runtime.Versioning;
using UserManager.Services;

namespace UserManager.Web;


public static class Startup
{
    public static void ConfigureHost(IHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((hostingContext, config) =>
        {
            config.AddJsonFile("appsettings.json",
                optional: true,
                reloadOnChange: true);
        });
            
        builder.ConfigureLogging(l =>
        {
            l.AddEventLog(c => c.SourceName = "UserManager");
        });

    }
    public static void ConfigureServices(IServiceCollection services)
    {
            
        services.AddRazorPages();
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        });
        services.AddEndpointsApiExplorer();
        services.AddTransient<IDataConversionService, DataConversionService>();
        services.AddTransient<IRequestWriterService, RequestWriterService>();            
    }
}