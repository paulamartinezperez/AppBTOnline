using AppBTOnline.Data;
using AppBTOnline.Models;
using Microsoft.Maui.Controls;


namespace AppBTOnline.Views;

[QueryProperty("Item", "Item")]


public partial class FinGame : ContentPage
{

    Player item;

    public Player Item
    {
        get => BindingContext as Player;
        set => BindingContext = value;
    }


    PlayerDatabase database;
    public FinGame(PlayerDatabase playerDatabase)
	{
		InitializeComponent();
        database = playerDatabase;
    }
}