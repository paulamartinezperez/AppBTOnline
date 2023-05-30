using System.Collections.ObjectModel;
using AppBTOnline.Data;
using AppBTOnline.Models;
namespace AppBTOnline.Views;

public partial class InfoAllPlayers : ContentPage
{
	PlayerDatabase database;

    public ObservableCollection<Player> Items { get; set; } = new();
    public InfoAllPlayers(PlayerDatabase playerDatabase)
	{
		InitializeComponent();
		database = playerDatabase;
		BindingContext = this;
	}

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var items = await database.GetItemsAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Items.Clear();
            foreach (var item in items)
                Items.Add(item);

        });
    }
    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"///InitGame", true, new Dictionary<string, object>
        {
            ["Item"] = new Player()
        });
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Player item)
            return;

        await Shell.Current.GoToAsync(nameof(InfoPlayer), true, new Dictionary<string, object>
        {
            ["Item"] = item
        });
    }
}