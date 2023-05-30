using AppBTOnline.Data;
using AppBTOnline.Models;

namespace AppBTOnline.Views;

[QueryProperty("Item", "Item")]

public partial class InfoCuestionsPlayer : ContentPage
{
    Player item;

    public Player Item
    {
        get => BindingContext as Player;
        set => BindingContext = value;
    }
    PlayerDatabase database;
    public InfoCuestionsPlayer(PlayerDatabase playerDatabase)
	{
		InitializeComponent();
        database = playerDatabase;

    }
}