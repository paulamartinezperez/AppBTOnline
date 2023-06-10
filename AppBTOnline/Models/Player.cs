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

}