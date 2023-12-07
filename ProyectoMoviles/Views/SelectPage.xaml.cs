namespace ProyectoMoviles.Views;

public partial class SelectPage : ContentPage
{
	public SelectPage()
	{
		InitializeComponent();
	}

	private void btn_Consultar(object sender, EventArgs e)
	{
        Navigation.PushAsync(new EventsPage());
    }

	private void btn_Agregar(object sender, EventArgs e)
	{
		Navigation.PushAsync(new AddEventPage());
	}
    
}