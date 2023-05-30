using AppBTOnline.Models;

namespace AppBTOnline.Data;

public static class PreguntasNivel1
{
    public static IList<Cuestion> Preguntas { get; private set; }

    static PreguntasNivel1()
    {
        Preguntas = new List<Cuestion>();

        Preguntas.Add(new Cuestion
        {
            ID = 0,
            Pregunta = "Empezamos este juego en la Playa Mayor de Madrid. Esta plaza de estilo Barroco fue inagurada en 1619." +
                        " En la actualidad es uno de los lugares emblematicos de Madrid, teniendo una comida típica la cual debeis adivinar," +
                        " por lo que aqúi dejamos las opciones:",
            Respuesta1 = "Paella",
            Respuesta2 = "Chocolate con Churros",
            Respuesta3 = "Bocadillo de Calamares",
            Solucion = "3",
            CoordLatitud = 40.415511,
            CoordLongitud = -3.7074009,
            Lugar = "Plaza Mayor",
        });

        Preguntas.Add(new Cuestion
        {
            ID = 1,
            Pregunta = "Otro de los lugares emblematicos de Madrid es la Puerta del Sol. En ella se encuentran varios elementos representativos de la ciudad, " +
                       "debeis de señalar el que no se encuentra en este lugar:",
            Respuesta1 = "Puerta de Alcalá",
            Respuesta2 = "El Oso y el madroño",
            Respuesta3 = "Placa del Kilómetro 0",
            Solucion = "1",
            CoordLatitud = 40.4167278,
            CoordLongitud = -3.7033387,
            Lugar = "Puerta del Sol",
        });

        Preguntas.Add(new Cuestion
        {
            ID = 2,
            Pregunta = "Nos encontramos en la Plaza de Cibeles, los aficionados de futbol sabrán que en esta plaza uno de los tres equipos de futbol de la capital celebra sus victorias. " +
                       "Como sabemos que no todo el mundo lo sabrá, aquí van unas pistas: Este equipo tiene 14 Champions, 35 Ligas y 20 Copas del rey... ¿Qué equipo es?",
            Respuesta1 = "Atletico de Madrid",
            Respuesta2 = "Real Madrid",
            Respuesta3 = "Rayo Vallecano",
            Solucion = "2",
            CoordLatitud = 40.419181,
            CoordLongitud = -3.694665,
            Lugar = "Plaza de Cibeles",
        });

        Preguntas.Add(new Cuestion
        {
            ID = 3,
            Pregunta = "Esta es la penúltima pista, estamos en el Templo de Debod, este monumento fue un regalo de un Pais para España en 1968," +
                       " si lo recorreis encontrareis el nombre de este Pais, el cual es la solución de la sigueinte pregunta",
            Respuesta1 = "República del Congo",
            Respuesta2 = "Arabia Saudí",
            Respuesta3 = "Egipto",
            Solucion = "3",
            CoordLatitud = 40.4240216,
            CoordLongitud = -3.7177695,
            Lugar = "Templo de Debod",
        });

        Preguntas.Add(new Cuestion
        {
            ID = 4,
            Pregunta = "¡Enhorabuena! Ha llegado hasta la última prueba....Estas situado en el Palacio Real, siendo este el Palacio más grande de Europa Occidental " +
                       "con 135000 metros cuadrados y 3418 habitaciones. Enfrente de este se encuentra la escultura de Felipe IV. Para eta prueba necesitamos que os acerqueis a ella" +
                       " y realiceis la siguiente operación matemática: (número de leones) * 4 + (patas del caballo en el aire) / 2. ¿Cuál es la solución?",
            Respuesta1 = "17",
            Respuesta2 = "18",
            Respuesta3 = "16",
            Solucion = "1",
            CoordLatitud = 40.417955,
            CoordLongitud = -3.714312,
            Lugar = "Palacio Real",
        });
    }

}

