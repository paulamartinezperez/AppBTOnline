using SQLite;

namespace AppBTOnline.Models;

public class Player
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string Name { get; set; }
    public string Apellidos { get; set; }
    public string CentroEducativo { get; set; }
    public int NumeroPrueba { get; set; }
    public  int Intentos_1 { get; set; }
    public int Intentos_2 { get; set; }
    public int Intentos_3 { get; set; }
    public int Intentos_4 { get; set; }
    public int Intentos_5 { get; set; }


}