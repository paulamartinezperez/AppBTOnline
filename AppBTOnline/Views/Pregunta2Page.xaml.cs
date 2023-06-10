using AppBTOnline.Data;
using AppBTOnline.Models;
using Microsoft.Maui.Controls;

namespace AppBTOnline.Views;

[QueryProperty("Item", "Item")]

public partial class Pregunta2Page : ContentPage
{
    Player item;

    public Player Item
    {
        get => BindingContext as Player;
        set => BindingContext = value;
    }

    string aux_resp_player;

    PlayerDatabase database;

    public Pregunta2Page(PlayerDatabase playerDatabase)
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
        Cuestion aux_item = aux.ElementAt(1);
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
        Cuestion aux_item = aux.ElementAt(1);

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
            Text = aux_item.Respuesta1
        }, 0, 0);

        grid.Add(new Label
        {
            Text = aux_item.Respuesta2
        }, 0, 1);

        grid.Add(new Label
        {
            Text = aux_item.Respuesta3
        }, 0, 2);

        myStackLayout.Children.Add(grid);
    }

    void respond()
    {
        var aux = PreguntasNivel1.Preguntas;
        Cuestion aux_item = aux.ElementAt(1);

        var myPicker = new Picker
        {
            Title = "Selecciona una opción",
            ItemsSource = new[] { aux_item.Respuesta1,aux_item.Respuesta2, aux_item.Respuesta3}
        };

        myPicker.Margin = new Thickness(0, 10, 0, 10);
        myStackLayout.Children.Add(myPicker);

        Content = myStackLayout;

        myPicker.SelectedIndexChanged += (sender, args) =>
        {
            var selectedOption = myPicker.SelectedItem as string;
            switch (selectedOption)
            {
                case "Puerta de Alcalá":
                    aux_resp_player = "1";
                    break;
                case "El Oso y el madroño":
                    aux_resp_player = "2";
                    break;
                case "Placa del Kilómetro 0":
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
        Cuestion aux_item = aux.ElementAt(1);

        var intento = new Intento();
        intento.IDPlayer = Item.ID;
        intento.IDCuestion = aux_item.ID;
        intento.NumeroIntento = await database.GetPlayerIntentoPreguntaCount(Item.ID, aux_item.ID) + 1;

        DateTime fechaActual = DateTime.Now;
        intento.Tiempo = fechaActual.ToString();


        if (aux_resp_player == aux_item.Solucion)
        {
            intento.Resultado = "correcto";
            await database.SaveIntento(intento);
            var prueba = database.AllPlayerintentos(Item.ID);

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
            intento.Resultado = "incorrecto";
            await database.SaveIntento(intento);
            var prueba = database.AllPlayerintentos(Item.ID);

            string text;
            text = "NO HAS RESPONDIDO CORRECTAMENTE";
            await DisplayAlert("Info", text, "OK");
        }
    }
}