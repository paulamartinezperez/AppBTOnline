using AppBTOnline.Data;
using AppBTOnline.Models;
using Microsoft.Maui.Controls;
using System.Diagnostics;

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

    async void OnViewAll(object sender, EventArgs e)
    {
        StackLayout stackLayout = new StackLayout
        {
            Spacing = 10,
            Margin = new Thickness(20, 25, 20, 25)
        };


        var initJuegoLabel = new Image
        {
            Source = "Images/tituloportada.png",
            Aspect = Aspect.AspectFill,
            Margin = new Thickness(20, 25, 20, 25)
        };
        stackLayout.Children.Add(initJuegoLabel);
        
        int aux_1 = await database.GetPlayerIntentoPreguntaCount(Item.ID, 0);
        var aux_2 = await database.GetPlayerIntentoPreguntaCount(Item.ID, 1);
        var aux_3 = await database.GetPlayerIntentoPreguntaCount(Item.ID, 2);
        var aux_4 = await database.GetPlayerIntentoPreguntaCount(Item.ID, 3);
        var aux_5 = await database.GetPlayerIntentoPreguntaCount(Item.ID, 4);
        stackLayout.Children.Add(CreateGrid("Nombre", Item.Name));
        stackLayout.Children.Add(CreateGrid("Apellidos", Item.Apellidos));
        stackLayout.Children.Add(CreateGrid("Centro Educativo", Item.CentroEducativo));
        stackLayout.Children.Add(CreateGrid("Intentos prueba 1", Convert.ToString(aux_1)));
        stackLayout.Children.Add(CreateGrid("Intentos prueba 2", Convert.ToString(aux_2)));
        stackLayout.Children.Add(CreateGrid("Intentos prueba 3", Convert.ToString(aux_3)));
        stackLayout.Children.Add(CreateGrid("Intentos prueba 4", Convert.ToString(aux_4)));
        stackLayout.Children.Add(CreateGrid("Intentos prueba 5", Convert.ToString(aux_5)));


        var finJuegoLabel = new Label
        {
            Text = "¡FIN DEL JUEGO!",
            HorizontalOptions = LayoutOptions.Center,
            HorizontalTextAlignment = TextAlignment.Center,
            Margin = new Thickness(70, 20, 70, 0)
        };
        stackLayout.Children.Add(finJuegoLabel);

        var imagenPortada = new Image
        {
            Source = "Images/imagenportada.png",
            Aspect = Aspect.AspectFill,
            Margin = new Thickness(0, 30, 0, 0)
        };
        stackLayout.Children.Add(imagenPortada);

        Content = stackLayout;
    }


}