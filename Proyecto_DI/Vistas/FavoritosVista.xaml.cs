using Proyecto_DI.Modelo;
using Proyecto_DI.Plantillas;
using System.Collections.ObjectModel;
namespace Proyecto_DI.Vistas;

public partial class FavoritosVista : Plantilla
{
	public FavoritosVista()
	{
		InitializeComponent();
        filtrarFavoritos(PaginaPrincipal.peliculas);
	}


    private void filtrarFavoritos(ObservableCollection<Pelicula> peliculas)
    {
        int usuarioId = Preferences.Default.Get(App.usuario_id, -1);
        List<Pelicula> resultados = new List<Pelicula>();
        List<int> listaId = App.favoritoRepositorio.listaIdPeliculas(usuarioId);

        foreach(Pelicula pelic in peliculas) 
        {
            foreach (int id in listaId) 
            {
                if(id == pelic.id) 
                {
                    pelic.color = Color.FromRgba(255, 255, 0, 255);
                    resultados.Add(pelic);
                }
            }
        }

        ObservableCollection<Pelicula>favoritos = new ObservableCollection<Pelicula>(resultados);

        if (favoritos.Count <= 0)
        {
            mensajeFavoritos.IsVisible = false;
        }
        else 
        {
            mensajeFavoritos.IsVisible= true;
        }

        listaPeliculas.ItemsSource = favoritos;

    }

    private async void cerrarSesion(object sender, EventArgs e)
    {
        bool respuesta = await DisplayAlert("Cerrar Sesión", "¿Deseas cerrar sesión?", "Si", "No");
        if (respuesta)
        {
            _ = cambiarLogin();
        }

    }

    private async void volverInicio(object sender, EventArgs e)
    {
        _ = cambiarIncio();

    }

    private async Task cambiarLogin()
    {
        await AppShell.Current.GoToAsync(nameof(Login));
    }

    private async Task cambiarIncio()
    {
        await AppShell.Current.GoToAsync(nameof(PaginaPrincipal));
    }
}