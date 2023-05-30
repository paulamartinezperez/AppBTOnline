using AppBTOnline.Data;
using AppBTOnline.Views;
using Microsoft.Extensions.Logging;

namespace AppBTOnline;

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
			})
			.UseMauiMaps();

        builder.Services.AddTransient<LogInPage>();
        builder.Services.AddTransient<InfoPlayer>();
        builder.Services.AddTransient<InfoAllPlayers>();
        builder.Services.AddTransient<InitGame>();
        builder.Services.AddTransient<MenuGame>();
        builder.Services.AddTransient<InfoCuestionsPlayer>();
        builder.Services.AddTransient<MapsPage>();
        builder.Services.AddTransient<Pregunta1Page>();
        builder.Services.AddTransient<Pregunta2Page>();
        builder.Services.AddTransient<Pregunta3Page>();
        builder.Services.AddTransient<Pregunta4Page>();
        builder.Services.AddTransient<Pregunta5Page>();
        builder.Services.AddTransient<FinGame>();


        builder.Services.AddSingleton<PlayerDatabase>();

        return builder.Build();
    }
}
