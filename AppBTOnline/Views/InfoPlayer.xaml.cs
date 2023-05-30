using AppBTOnline.Data;
using AppBTOnline.Models;

namespace AppBTOnline.Views;

[QueryProperty("Item", "Item")]

public partial class InfoPlayer : ContentPage
{
	Player item;

	public Player Item
	{
		get => BindingContext as Player;
		set => BindingContext = value;
	}
	PlayerDatabase database;
	public InfoPlayer(PlayerDatabase playerDatabase)
	{
		InitializeComponent();
		database = playerDatabase;
	}


}