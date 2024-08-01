using MauiApp_test.MVVM.Models;
using MauiApp_test.Repositories;
using Microsoft.Extensions.Logging;
using SQLite;
using SQLiteNetExtensions.Extensions;
using SQLitePCL;

namespace MauiApp_test
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif    
            builder.Services.AddSingleton<BaseRepository<Courses>>();

            SQLitePCL.Batteries_V2.Init();

            return builder.Build();
        }
    }
}
