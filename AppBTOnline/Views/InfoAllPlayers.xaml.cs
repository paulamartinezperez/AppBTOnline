using System.Collections.ObjectModel;
using AppBTOnline.Data;
using AppBTOnline.Models;
namespace AppBTOnline.Views;

public partial class InfoAllPlayers : ContentPage
{
    PlayerDatabase database;

    Player item;

    public Player Item
    {
        get => BindingContext as Player;
        set => BindingContext = value;
    }

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


    private Grid CreateGrid(string labelText, string bindingPath)
    {
        Grid grid = new Grid
        {
            RowDefinitions =
            {
                new Microsoft.Maui.Controls.RowDefinition()
            },
            ColumnDefinitions =
            {
                new Microsoft.Maui.Controls.ColumnDefinition(),
                new Microsoft.Maui.Controls.ColumnDefinition()

            }
        };

        grid.Add(new Label
        {
            Text = labelText
        }, 0, 0);

        grid.Add(new Label
        {
            Text = bindingPath
        }, 1, 0);


        return grid;
    }


    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as Player;

        StackLayout stackLayout = new StackLayout
        {
            Spacing = 10,
            Margin = new Thickness(20, 25, 20, 25)
        };

        if (selectedItem != null)
        {
            int aux_1 = await database.GetPlayerIntentoPreguntaCount(selectedItem.ID, 0);
            var aux_2 = await database.GetPlayerIntentoPreguntaCount(selectedItem.ID, 1);
            var aux_3 = await database.GetPlayerIntentoPreguntaCount(selectedItem.ID, 2);
            var aux_4 = await database.GetPlayerIntentoPreguntaCount(selectedItem.ID, 3);
            var aux_5 = await database.GetPlayerIntentoPreguntaCount(selectedItem.ID, 4);
            stackLayout.Children.Add(CreateGrid("Nombre", selectedItem.Name));
            stackLayout.Children.Add(CreateGrid("Apellidos", selectedItem.Apellidos));
            stackLayout.Children.Add(CreateGrid("Centro Educativo", selectedItem.CentroEducativo));
            stackLayout.Children.Add(CreateGrid("Intentos prueba 1", Convert.ToString(aux_1)));
            stackLayout.Children.Add(CreateGrid("Intentos prueba 2", Convert.ToString(aux_2)));
            stackLayout.Children.Add(CreateGrid("Intentos prueba 3", Convert.ToString(aux_3)));
            stackLayout.Children.Add(CreateGrid("Intentos prueba 4", Convert.ToString(aux_4)));
            stackLayout.Children.Add(CreateGrid("Intentos prueba 5", Convert.ToString(aux_5)));

            var imagenPortada = new Image
            {
                Source = "Images/imagenportada.png",
                Aspect = Aspect.AspectFill,
                Margin = new Thickness(0, 30, 0, 0)
            };
            stackLayout.Children.Add(imagenPortada);


            var myButton = new Button
            {
                Text = "Lista jugadores",
                FontSize = 15,
                TextColor = Color.FromHex("#573517"),
                BackgroundColor = Color.FromHex("#EDBCC0"),
                BorderWidth = 2,
                BorderColor = Color.FromHex("#EDBCC0")
            };

            myButton.Clicked += MyButton_Clicked;
            myButton.Margin = new Thickness(20, 20, 20, 10);

            stackLayout.Children.Add(myButton);

           
            Content = stackLayout;
            (sender as CollectionView).SelectedItem = null;
        }

    }



    async void MyButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(InfoAllPlayers), true, new Dictionary<string, object>
        {
            ["Item"] = Item
        });
    }

}