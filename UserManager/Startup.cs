using UserManager.Services;

namespace UserManager.Web
{
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
        }
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<IRequestWriterService, RequestWriterService>();            
        }
    }
}
