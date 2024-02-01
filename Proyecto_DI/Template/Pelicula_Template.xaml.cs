using Proyecto_DI.Modelo;
using System.Collections.ObjectModel;
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
        inicializarVariables();
       
	}

    private void inicializarVariables() 
    {
        try
        {
            usuarioId = Preferences.Default.Get(App.usuario_id, -1);
        }
        catch (Exception e)
        { 
            System.Diagnostics.Debug.WriteLine( "Mensaje de error: " + e.Message);
        }

    }



    // pasar una lista de ids y mirar si coincide con este id

    private async void cambiarFavoritos(object sender, EventArgs e)
    {
        peliculaId = (int)((Pelicula)((Microsoft.Maui.Controls.BindableObject)sender).BindingContext).id;
        favoritos = App.favoritoRepositorio.verPeliculaUsuario(usuarioId, peliculaId);

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