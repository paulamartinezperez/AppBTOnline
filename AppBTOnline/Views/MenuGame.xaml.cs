using AppBTOnline.Data;
using AppBTOnline.Models;

namespace AppBTOnline.Views;

[QueryProperty("Item", "Item")]

public partial class MenuGame : ContentPage
{
    Player item;

    public Player Item
    {
        get => BindingContext as Player;
        set => BindingContext = value;
    }
    PlayerDatabase database;

    public MenuGame(PlayerDatabase playerDatabase)
	{
		InitializeComponent();
        database = playerDatabase;
    }

    async void OnMapGame(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(MapsPage), true, new Dictionary<string, object>
        {
            ["Item"] = Item
        });
    }

    async void OnInformation(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(InfoPlayer), true, new Dictionary<string, object>
        {
            ["Item"] = Item
        }); 
    }

}