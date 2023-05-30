using AppBTOnline.Views;

namespace AppBTOnline;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(InfoAllPlayers), typeof(InfoAllPlayers));
        Routing.RegisterRoute(nameof(InfoPlayer), typeof(InfoPlayer));
        Routing.RegisterRoute(nameof(LogInPage), typeof(LogInPage));
        Routing.RegisterRoute(nameof(MenuGame), typeof(MenuGame));
        Routing.RegisterRoute(nameof(InfoCuestionsPlayer), typeof(InfoCuestionsPlayer));
        Routing.RegisterRoute(nameof(MapsPage), typeof(MapsPage));
        Routing.RegisterRoute(nameof(Pregunta1Page), typeof(Pregunta1Page));
        Routing.RegisterRoute(nameof(Pregunta2Page), typeof(Pregunta2Page));
        Routing.RegisterRoute(nameof(Pregunta3Page), typeof(Pregunta3Page));
        Routing.RegisterRoute(nameof(Pregunta4Page), typeof(Pregunta4Page));
        Routing.RegisterRoute(nameof(Pregunta5Page), typeof(Pregunta5Page));
        Routing.RegisterRoute(nameof(FinGame), typeof(FinGame));


    }
}
