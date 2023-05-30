using AppBTOnline.Data;
using AppBTOnline.Models;
using Grid = Microsoft.Maui.Controls.Grid;

namespace AppBTOnline.Views;

[QueryProperty("Item", "Item")]

public partial class Pregunta1Page : ContentPage
{
    Player item;

    public Player Item
    {
        get => BindingContext as Player;
        set => BindingContext = value;
    }

    string aux_resp_player;

    PlayerDatabase database;

    public Pregunta1Page(PlayerDatabase playerDatabase)
	{
		InitializeComponent();
        database = playerDatabase;
        Cuestion();
        //Answer();
        respond();
        buttonsend();
    }

    void Cuestion()
    {
        var aux = PreguntasNivel1.Preguntas;
        Cuestion aux_item = aux.ElementAt(0);
        Label label = new Label();
        label.Text = aux_item.Pregunta;
        label.HorizontalTextAlignment = TextAlignment.Center;
        label.FontSize = 18;
        label.FontAttributes = FontAttributes.Bold;
        label.Margin = new Thickness(10, 20, 10, 20);
        myStackLayout.Children.Add(label);

    }

    void Answer()
    {
        var aux = PreguntasNivel1.Preguntas;
        Cuestion aux_item = aux.ElementAt(0);

        Grid grid = new Grid
        {
            RowDefinitions =
            {
                new Microsoft.Maui.Controls.RowDefinition(),
                new Microsoft.Maui.Controls.RowDefinition(),
                new Microsoft.Maui.Controls.RowDefinition()
            },
            ColumnDefinitions =
            {
                new Microsoft.Maui.Controls.ColumnDefinition()
            }
        };

        grid.Add(new Label
        {
            Text = aux_item.Respuesta1,
            HorizontalTextAlignment = TextAlignment.Center,
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
            Margin = new Thickness(5, 5, 5, 5)
        }, 0, 0);

        grid.Add(new Label
        {
            Text = aux_item.Respuesta2,
            HorizontalTextAlignment = TextAlignment.Center,
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
            Margin = new Thickness(5, 5, 5, 5)
    }, 0, 1);

        grid.Add(new Label
        {
            Text = aux_item.Respuesta3,
            HorizontalTextAlignment = TextAlignment.Center,
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
            Margin = new Thickness(5, 5, 5, 5)
        }, 0, 2);

        grid.Margin = new Thickness(0, 10, 0, 10);
        myStackLayout.Children.Add(grid);
    }

    void respond()
    {
        var myPicker = new Picker
        {
            Title = "Selecciona una opción",
            ItemsSource = new[] { "Paella", "Chocolate con Churros", "Bocadillo de Calamares" }
        };

        myPicker.Margin = new Thickness(0, 10, 0, 10);
        myStackLayout.Children.Add(myPicker);

        Content = myStackLayout;

        myPicker.SelectedIndexChanged += (sender, args) =>
        {
            var selectedOption = myPicker.SelectedItem as string;
            switch (selectedOption)
            {
                case "Paella":
                    aux_resp_player = "1";
                    break;
                case "Chocolate con Churros":
                    aux_resp_player = "2";
                    break;
                case "Bocadillo de Calamares":
                    aux_resp_player = "3";
                    break;
            }
        };

    }


    void buttonsend()
    {
        var myButton = new Button
        {
            Text = "¡Comprobar!",
            FontSize = 15,
            TextColor = Color.FromHex("#573517"),
            BackgroundColor = Color.FromHex("#EDBCC0"),
            BorderWidth = 2,
            BorderColor = Color.FromHex("#EDBCC0")
        };

        myButton.Clicked += MyButton_Clicked;
        myButton.Margin = new Thickness(20, 20, 20, 10);

        myStackLayout.Children.Add(myButton);

        var backgroundImage = new Image()
        {
            Source = new FileImageSource() { File = "imagenportada.png" }
        };

        myStackLayout.Children.Add(backgroundImage);
    }

    async void MyButton_Clicked(object sender, EventArgs e)
    {
        var aux = PreguntasNivel1.Preguntas;
        Cuestion aux_item = aux.ElementAt(0);
        if (aux_resp_player == aux_item.Solucion)
        {
            Item.Intentos_1 = Item.Intentos_1 + 1;
            Item.NumeroPrueba = Item.NumeroPrueba + 1;
            await database.SaveItemAsync(Item);
            await DisplayAlert("Enhorabuena!", "Has respondido correctamente, por lo que pasas a la siguiente pista!", "Aceptar");
            await Shell.Current.GoToAsync(nameof(MapsPage), true, new Dictionary<string, object>
            {
                ["Item"] = Item
            });

        }
        else
        {
            Item.Intentos_1 = Item.Intentos_1 + 1;
            string text;
            text = "NO HAS RESPONDIDO CORRECTAMENTE";
            await DisplayAlert("Info", text, "OK");
        }
    }


}