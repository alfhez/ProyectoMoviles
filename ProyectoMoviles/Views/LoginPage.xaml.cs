using ProyectoMoviles.Models;
using Newtonsoft.Json;
using System.Text;
using ProyectoMoviles;

namespace ProyectoMoviles.Views;

public partial class LoginPage : ContentPage
{
    HttpClient client = new HttpClient();
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        string url = "https://proyectomovilesapi20231207075906.azurewebsites.net/api/Cuentas/login";
        User user = new User
        {
            UserName = txtUsuario.Text,
            Email = "string",
            Password = txtPassword.Text
        };
        string jsonUser = JsonConvert.SerializeObject(user);
        Console.WriteLine(jsonUser);
        StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
        var respuesta = await client.PostAsync(url, content);
        if (respuesta.IsSuccessStatusCode)
        {
            var tokenString = respuesta.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<UserToken>(tokenString.Result);
            if (respuesta.IsSuccessStatusCode)
            {
                await SecureStorage.SetAsync("token", json.Token);
                await Navigation.PushAsync(new SelectPage());
            }
        }
        else
        {
            await DisplayAlert("Error", "Error en los datos del usuario", "Ok");
        }
    }

}