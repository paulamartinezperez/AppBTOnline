using AppBTOnline.Data;
using AppBTOnline.Models;

namespace AppBTOnline.Views;

[QueryProperty("Item", "Item")]

public partial class LogInPage : ContentPage
{
	Player item;
	
	public Player Item
	{
		get => BindingContext as Player;
		set => BindingContext = value;
	}
	PlayerDatabase database;
	public LogInPage(PlayerDatabase playerDatabase)
	{
		InitializeComponent();
		database = playerDatabase;
	}

    async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Item.Name) || string.IsNullOrWhiteSpace(Item.Apellidos) || string.IsNullOrEmpty(Item.CentroEducativo))
        {
            await DisplayAlert("Faltan datos", "todos los datos son obligatorios a�adelos, porfa :)", "OK");
            return;
        }

        bool playerExists = await database.CheckPlayerDetailsAsync(Item.Name, Item.Apellidos, Item.CentroEducativo);

        //if (playerExists)
       // {
       //     await DisplayAlert("Error de usuario", "Este usuario ya existe en nuestra base de datos :(", "OK");
            return; // Aqu� puedes detener la ejecuci�n o realizar alguna otra acci�n
      //  }

        Item.NumeroPrueba = 0;

        await database.SaveItemAsync(Item);

        await Shell.Current.GoToAsync(nameof(MenuGame), true, new Dictionary<string, object>
        {
            ["Item"] = Item
        });
    }
}