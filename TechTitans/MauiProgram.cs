using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TechTitans.Repositories;
using System.Reflection;
using CommunityToolkit.Maui;

namespace TechTitans
{
    public static class MauiProgram
    {
        public static IConfiguration Configuration { get; private set; }
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TechTitans.appsettings.json");
            builder.Configuration.AddJsonStream(stream).Build();
            var app = builder.Build();
            Configuration = app.Services.GetService<IConfiguration>();
            return app;
        }
    }
}
