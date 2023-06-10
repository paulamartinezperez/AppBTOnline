using SQLite;

namespace AppBTOnline.Models;

public class Intento
{
    public int IDPlayer { get; set; }
    public int IDCuestion { get; set; }
    public int  NumeroIntento { get; set; }
    public string Resultado { get; set; }
    public string Tiempo { get; set; }

}