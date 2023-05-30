
namespace AppBTOnline.Models;

public class Cuestion
{
    public int ID { get; set; }
    public string Pregunta { get; set; }
    public string Respuesta1 { get; set; }
    public string Respuesta2 { get;set; }
    public string Respuesta3 { get; set; }
    public string Solucion { get;set; }
    public double CoordLatitud { get;set; }
    public double CoordLongitud { get;set; }

    public string Lugar { get; set; }

}

