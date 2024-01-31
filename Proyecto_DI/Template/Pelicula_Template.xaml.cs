using Proyecto_DI.Modelo;
using System.Numerics;

namespace Proyecto_DI.Template;

public partial class Pelicula_Template : ContentView
{
    public Pelicula pelicula;

    private bool favoritos = false;
    private String mensaje;

    private int usuarioId;
    private int peliculaId;

	public Pelicula_Template()
	{
		InitializeComponent();

        pelicula = new Pelicula();
        BindingContext = pelicula;

        inicializarVariables();
        inicializarFavoritos();
	}

    private void inicializarVariables() 
    {
        try
        {
            usuarioId = Preferences.Default.Get(App.usuario_id, -1);
            lblPelicula.BindingContext = pelicula.id;
            peliculaId = int.Parse(lblPelicula.Text);
            System.Diagnostics.Debug.WriteLine("El id es: " + peliculaId);


        }
        catch (Exception e)
        { 
            System.Diagnostics.Debug.WriteLine( "Mensaje de error: " + e.Message);
        }

    }

    private void inicializarFavoritos()
    {

       favoritos = App.favoritoRepositorio.verPeliculaUsuario(usuarioId, peliculaId);

        if (favoritos)
        {
            btnFavoritos.TextColor = Color.FromHex("#F0FF00");
        }
        else
        {
            btnFavoritos.TextColor = Color.FromHex("#979090");
        }
    }

    // pasar una lista de ids y mirar si coincide con este id

    private async void cambiarFavoritos(object sender, EventArgs e)
    {
        peliculaId = ( int )( ( Pelicula ) ( ( Microsoft.Maui.Controls.BindableObject )sender ).BindingContext ).id;

        if (!favoritos)
        {
            favoritos = true;
            btnFavoritos.TextColor = Color.FromHex("#F0FF00");
            App.favoritoRepositorio.add(new Favorito{Pelicula_id = peliculaId, Usuario_id= usuarioId});
            mensaje = "Elemento añadido a favoritos";
        }
        else
        {
            favoritos = false;
            btnFavoritos.TextColor = Color.FromHex("#979090");
            App.favoritoRepositorio.delete(usuarioId, peliculaId);
            mensaje = "Elemento eliminado de favoritos";
        }
        await Application.Current.MainPage.DisplayAlert("Lista de Favoritos", mensaje, "Ok");
    }

  

}