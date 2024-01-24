namespace Proyecto_DI.Template;

public partial class Pelicula_Template : ContentView
{
    private bool favoritos = false;

	public Pelicula_Template()
	{
		InitializeComponent();
	}
	/*
    private void cambiarFavoritos(object sender, EventArgs e)
    {

        if (!favoritos)
		{
			favoritos = true;
			btnFavoritos.BackgroundColor = "blue";
        }
		else 
		{
			favoritos = false;
			btnFavoritos.BackgroundColor = new SolidColorBrush(Green);
		}
    } */
}