using ProyectoMoviles.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using ProyectoMoviles.Models;
using System.Text;

namespace ProyectoMoviles.Views;

public partial class AddEventPage : ContentPage
{
	public AddEventPage()
	{
		InitializeComponent();
	}

    private readonly HttpClient client = new HttpClient();
    

    private async void btnAgregar_Clicked(object sender, EventArgs e)
    {
        string url = "https://dispositivosmovilesapi.azure-api.net/api/Eventos/AgregarEvento";

        var subscriptionKey = "812606be6db34052afd1c411efad6587";  // Replace with your actual subscription key

        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

        var respuesta = await client.GetAsync(url);
        Evento evento = new Evento
        {
            Nombre = txtNombre.Text,
            Descripcion = txtDescripcion.Text,
            Fecha = txtFecha.Text,
            Hora = txtHora.Text,
        };
        

        string eventoJson = JsonConvert.SerializeObject(evento);

        StringContent content = new StringContent(eventoJson, Encoding.UTF8, "application/json");

        var respuestaPost = await client.PostAsync(url, content);

        if (respuestaPost.IsSuccessStatusCode)
        {
            await Navigation.PushAsync(new SelectPage());
        }
        else
        {
            await DisplayAlert("Error", "No se pudo agregar el evento", "Ok");
        }
        
    }

}