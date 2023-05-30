using System.Collections.ObjectModel;
using AppBTOnline.Data;
using AppBTOnline.Models;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace AppBTOnline.Views;

[QueryProperty("Item", "Item")]

public partial class InitGame : ContentPage
{
    Player item;

    public Player Item
    {
        get => BindingContext as Player;
        set => BindingContext = value;
    }
    PlayerDatabase database;

    public ObservableCollection<Player> PlayerList { get; set; } = new();
	public InitGame(PlayerDatabase playerDatabase)
	{   
		InitializeComponent();
		database= playerDatabase;
		BindingContext = this;
    }

    async void OnStartGame(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(LogInPage), true, new Dictionary<string, object>
        {
            ["Item"] = new Player()
        });
    }

    
    async void OnViewAll(object sender, EventArgs e)
    {
        string claveCorrecta = "clave123"; // Clave correcta para acceder

        string claveIngresada = await DisplayPromptAsync("Acceso", "Ingrese la clave:");

        if (claveIngresada == claveCorrecta)
        {
            await DisplayAlert("Acceso concedido", "Bienvenido", "Aceptar");
            // Aquí puedes continuar con el flujo de la aplicación
            await Shell.Current.GoToAsync(nameof(InfoAllPlayers), true, new Dictionary<string, object>
            {
                ["Item"] = Item
            });
        }
        else
        {
            await DisplayAlert("Acceso denegado", "Clave incorrecta", "Aceptar");
            // Aquí puedes realizar alguna acción adicional en caso de acceso denegado
        }
    }
}