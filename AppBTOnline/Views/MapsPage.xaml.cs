using AppBTOnline.Data;
using AppBTOnline.Models;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Controls.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;

namespace AppBTOnline.Views;

[QueryProperty("Item", "Item")]


public partial class MapsPage : ContentPage
{
    Player item;

    public Player Item
    {
        get => BindingContext as Player;
        set => BindingContext = value;
    }
    PlayerDatabase database;

    private CancellationTokenSource _cancelTokenSource;
    private bool _isCheckingLocation;
    private double latitud_act;
    private double longitud_act;

    public MapsPage(PlayerDatabase playerDatabase)
	{
		InitializeComponent();
        GetCurrentLocation();
        database = playerDatabase;
    }

    public async Task GetCurrentLocation()
    {
        try
        {
            _isCheckingLocation = true;

            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            _cancelTokenSource = new CancellationTokenSource();

            Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

            if (location != null)
            {
                Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                longitud_act = location.Longitude;
                latitud_act = location.Latitude;
            }
                
        }

        catch (Exception ex) {}
        finally
        {
            _isCheckingLocation = false;
        }
    }

    void OnButtonMaped(object sender, EventArgs e)
    {
        var value = PreguntasNivel1.Preguntas;
        var pista = Item.NumeroPrueba;
        foreach (var pin in value)
        {
            if(pin.ID == pista)
            {
                var name_pin = "lugar_" + pin.ID.ToString();
                var addres_pin = "madrid_" + pin.ID.ToString();

                Pin aux = new Pin
                {
                    Location = new Location(pin.CoordLatitud, pin.CoordLongitud),
                    Label = name_pin,
                    Address = addres_pin,
                    Type = PinType.Generic
                };
                map.Pins.Add(aux);
            }
        }
    }
  
    void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        double zoomLevel = e.NewValue;
        double latlongDegrees = 360 / (Math.Pow(2, zoomLevel));
        if (map.VisibleRegion != null)
        {
            map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongDegrees, latlongDegrees));
        }
    }

    void OnButtonClicked(object sender, EventArgs e)
    {
        Button button = sender as Button;
        switch (button.Text)
        {
            case "Street":
                map.MapType = MapType.Street;
                break;
            case "Satellite":
                map.MapType = MapType.Satellite;
                break;
            case "Hybrid":
                map.MapType = MapType.Hybrid;
                break;
        }
    }

    async void OnStartPrueba(object sender, EventArgs e)
    {
        GetCurrentLocation();
        var aux = PreguntasNivel1.Preguntas.ElementAt(Item.NumeroPrueba);
        var lat_pregunta = aux.CoordLatitud;
        var lon_pregunta = aux.CoordLongitud;
       

        if (Math.Abs(lat_pregunta - latitud_act) < 0.01 && Math.Abs(lon_pregunta - longitud_act) < 0.01)
        {
            if(Item.NumeroPrueba == 0)
                await Shell.Current.GoToAsync(nameof(Pregunta1Page), true, new Dictionary<string, object>{ ["Item"] = Item });

            if (Item.NumeroPrueba == 1)
                await Shell.Current.GoToAsync(nameof(Pregunta2Page), true, new Dictionary<string, object> { ["Item"] = Item });

            if (Item.NumeroPrueba == 2)
                await Shell.Current.GoToAsync(nameof(Pregunta3Page), true, new Dictionary<string, object> { ["Item"] = Item });

            if (Item.NumeroPrueba == 3)
                await Shell.Current.GoToAsync(nameof(Pregunta4Page), true, new Dictionary<string, object> { ["Item"] = Item });

            if (Item.NumeroPrueba == 4)
                await Shell.Current.GoToAsync(nameof(Pregunta5Page), true, new Dictionary<string, object> { ["Item"] = Item });

        }
        else
        {
            string text;
            text = "No estás en el lugar correcto, debes estar en " + aux.Lugar;
            await DisplayAlert("Info", text, "OK");
        }

       
    }


}