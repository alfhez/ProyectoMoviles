using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using ProyectoMoviles.Models;

namespace ProyectoMoviles
{
    public partial class EventsPage : ContentPage
    {
        HttpClient client = new HttpClient();
        public ObservableCollection<Evento> Eventos { get; set; }


        List<string> ImagesUrls = new List<string>{
            "https://cdn.epicstream.com/images/ncavvykf/epicstream/9cc0ede60c2f30c194bd3441eaf276bf3dacf715-2880x1576.png",
            "https://cdn.epicstream.com/images/ncavvykf/epicstream/fda7364248a7d26e8713c10154d3ca2d6a1a6b2e-1400x788.jpg",
            "https://cdn.epicstream.com/images/ncavvykf/epicstream/5ad3fe8166d9f0af249eb8e1e6e541b65aeb6385-2560x1440.jpg",
            "https://cdn.epicstream.com/images/ncavvykf/epicstream/f322e44513820ebaa69190579c7dbedd475e90d6-1177x631.png",
            "https://cdn.epicstream.com/images/ncavvykf/epicstream/13eb47a3eff0597424492be414a9209df6a9d57d-1280x720.jpg",
            "https://cdn.epicstream.com/images/ncavvykf/epicstream/9f61396712ba4244e029d0646e1420fdea90567b-1277x716.jpg",
            "https://cdn.epicstream.com/images/ncavvykf/epicstream/1817da2b50130ad06c79820dd8024b9d4bac89f1-1280x628.jpg",
            "https://cdn.epicstream.com/images/ncavvykf/epicstream/bdebb53dcfd236e5af82f286832790dcd9d6031f-2880x1354.jpg",
            "https://cdn.epicstream.com/images/ncavvykf/epicstream/e20f3441acd2ca62fc1d138b3dc4f83b500a70e7-1440x810.jpg",
            "https://cdn.epicstream.com/images/ncavvykf/epicstream/1e307abdeb86a22315ae680409aee1fd388b2162-1280x720.jpg",
            "https://cdn.epicstream.com/images/ncavvykf/epicstream/f62eec913da23dd0c43c3a08e1d3ba3249a6deaf-1920x1080.jpg",
            "https://cdn.epicstream.com/images/ncavvykf/epicstream/0284f4a148f9a40cbeb4ef50f464737f4a04f2cc-1920x1080.jpg",
            "https://cdn.epicstream.com/images/ncavvykf/epicstream/aafbee8a93b4299bc1ed5485f65735a6bd62143d-2876x1568.jpg",
            "https://cdn.epicstream.com/images/ncavvykf/epicstream/9ffdbc78eb2ab25508c790f659f23eed8ceb5762-2048x1153.jpg"
        };

        public EventsPage()
        {
            InitializeComponent();
            ObtenerEventos();
            BindingContext = this;

            // Initialize the Eventos collection and call ObtenerEventos
            //Eventos = new ObservableCollection<Evento>();


        }

        private async void ObtenerEventos()
        {
            ObservableCollection<Evento> EventosAPI = new ObservableCollection<Evento>();

            string url = "https://dispositivosmovilesapi.azure-api.net/api/Eventos/ObtenerEventos";

            var subscriptionKey = "812606be6db34052afd1c411efad6587";  // Replace with your actual subscription key

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            
            var respuesta = await client.GetAsync(url);

            
            if (!respuesta.IsSuccessStatusCode)
            {
                await DisplayAlert("Error", "No se pudo obtener los datos", "Ok");
                return;
            }
            else
            {
                var json = await respuesta.Content.ReadAsStringAsync();
                EventosAPI = JsonConvert.DeserializeObject<ObservableCollection<Evento>>(json);
                if (EventosAPI.Count == 0)
                {
                    await DisplayAlert("Menaje", "No existen datos para mostrar", "Ok");
                }

                foreach (var evento in EventosAPI)
                {
                    // Create a Label for each event
                    var label = new Label
                    {
                        Text = $"Nombre: {evento.Nombre},\n Fecha del Evento: {evento.Fecha}",
                        Margin = new Thickness(0, 0, 0, 10) // Optional margin for spacing
                    };

                    // Add the Label to the StackLayout
                    eventosStackLayout.Children.Add(label);
                }




            }
        }

    }
}


