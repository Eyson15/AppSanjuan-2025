using System.Collections.ObjectModel;

namespace AppSanJuan_2025;

public partial class NovenasPage : ContentPage
{
    public ObservableCollection<GrupoEventos> EventosAgrupados { get; set; }

    public NovenasPage()
    {
        InitializeComponent();
        EventosAgrupados = new ObservableCollection<GrupoEventos>(AgruparPorDia(ObtenerEventos()));
        BindingContext = this;
    }

    public class Evento
    {
        public string Titulo { get; set; }
        public string Lugar { get; set; }
        public string Dia { get; set; }  // Ej. "21 de junio"
        public string Hora { get; set; }
        public string Imagen { get; set; }
    }

    public class GrupoEventos : ObservableCollection<Evento>
    {
        public string Name { get; set; }

        public GrupoEventos(string name, IEnumerable<Evento> eventos) : base(eventos)
        {
            Name = name;
        }
    }

    private List<Evento> ObtenerEventos()
    {
        return new List<Evento>
            {
                new Evento { Dia = "13 de junio", Hora = "2:00 PM", Titulo = "Reseña", Lugar = "Fundo Tuctuhuasi - Chota: \r\n- Entrada triunfal de la imagen del patrón “San Juan Bautista” desde el Fundo Tuctuhuasi.\r\n ACTIVIDADES:\r\n- Santa Misa en la I.E. “Almirante Miguel Grau\r\n- Procesión de la imagen desde el Fundo Tuctuhuasi a la ciudad de Chota.\r\n- Recepción del Santo Patrón “San Juan Bautista” en el sector San Mateo.\r\n- Reencuentro e ingreso de San Juan Bautista a la Plaza de Armas", Imagen = "reseña.png" },
                new Evento { Dia = "13 de junio", Hora = "10:00 PM", Titulo = "Primera Novena", Lugar = "Plaza de Armas - Chota:  COMUNIDADES CAMPESINAS: Agaisbamaba, Toril, \r\nChororco, San Antonio, San Miguel de Pangoray, \r\nParaíso e Iraca Grande.\r\n DISTRITOS: Cochabamba y Chimbán.\r\n PARTICIPACIÓN ARTÍSTICA:\r\n Voces y Cuerdas de Cutervo.", Imagen = "n1.jpg" },
                new Evento { Dia = "14 de junio", Hora = "10:00 PM", Titulo = "Segundo Día de Novena", Lugar = "Plaza de Armas - Chota: COMUNIDADES CAMPESINAS: Colpamayo, Conga \r\nBlanca, Capillapampa, Quinuamayo, Negropampa, \r\nChucumaca, Chaupelanche y Huascarcocha.\r\n DISTRITOS: . Pión y Huambos\r\n PARTICIPACIÓN ARTÍSTICA:\r\n Chavales del Ritmo / Neyser Idrogo y Orquesta \r\nArmonía Nova.", Imagen = "n2.jpg" },
                new Evento { Dia = "15 de junio", Hora = "10:00 AM", Titulo = "Tercer Día de Novena", Lugar = "Plaza de Armas - Chota: COMUNIDADES CAMPESINAS: Yuracyacu, \r\nChimchim, San Francisco, Selleropat Alto, Silleropata \r\nBajo, Rejopampa y Vista Alegre.\r\n DISTRITOS: Choropampa y Llama.\r\n PARTICIPACIÓN ARTÍSTICA:\r\n Kelly Saldaña y sus Claveles del Amor.", Imagen = "n3.jpg" },
                new Evento { Dia = "22 de junio", Hora = "7:00 AM", Titulo = "Identidad Chotana", Lugar = "Plaza de Armas", Imagen = "identidad.jpg" },
                new Evento { Dia = "24 de junio", Hora = "10:00 PM", Titulo = "Agrupación Colonial en concierto", Lugar = "Plaza de Armas", Imagen = "colonial.jpg" }
            };
    }

    private List<GrupoEventos> AgruparPorDia(List<Evento> eventos)
    {
        return eventos
            .GroupBy(e => e.Dia)
            .Select(g => new GrupoEventos(g.Key, g))
            .ToList();
    }

    private async void CompartirPorWhatsApp(Evento evento)
    {
        string texto = $"¡No te pierdas \"{evento.Titulo}\" el {evento.Dia} a las {evento.Hora} en {evento.Lugar}!";
        string url = $"https://wa.me/?text={Uri.EscapeDataString(texto)}";

        await Launcher.Default.OpenAsync(url);
    }
}

