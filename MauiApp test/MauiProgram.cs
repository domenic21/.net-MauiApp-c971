using CommunityToolkit.Maui;
using MauiApp_test.MVVM.Models;
using MauiApp_test.Repositories;
using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;

namespace MauiApp_test
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseLocalNotification()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif    
            builder.Services.AddSingleton<BaseRepository<Courses>>();
            builder.Services.AddSingleton<BaseRepository<Terms>>();

            builder.Services.AddSingleton<BaseRepository<Instructor>>();
            builder.Services.AddSingleton<BaseRepository<Assessment>>();

            SQLitePCL.Batteries_V2.Init();

            return builder.Build();
        }
    }
}
