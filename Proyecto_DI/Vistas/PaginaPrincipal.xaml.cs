using Newtonsoft.Json;
using Proyecto_DI.Modelo;
using System.Collections.ObjectModel;

namespace Proyecto_DI.Vistas;

public partial class PaginaPrincipal : Plantillas.Plantilla
{
    private Usuario usuario = new Usuario();
	public static ObservableCollection<Pelicula> peliculas = new ObservableCollection<Pelicula>();
	private String seleccion;
 

    public PaginaPrincipal()
	{
		InitializeComponent();
		consultaHttp();
        inicializarUsuario();
	}

    // Conexion a la api
	private async void consultaHttp()
	{
		String host = "https://api.themoviedb.org/3/discover/movie?api_key=0bba8bfe2dc15305ae2e105a8003ce7a";
		
		HttpClient httpClient= new HttpClient();

		String respuesta =  await httpClient.GetStringAsync(host);

        Resultado resultado = JsonConvert.DeserializeObject<Resultado>(respuesta);

        incializarFavoritos(resultado.results);
        
        peliculas = resultado.results;

		actualizarLista();

	}

    // actualiza la lista 
	private void actualizarLista ()
	{
		listaPeliculas.ItemsSource = peliculas;
    }

    // Busca las peliculas dependiendo del picker
    private void buscarPeliculas(object sender, EventArgs e)
    {
		List<Pelicula> results = new List<Pelicula>(peliculas);

		switch (seleccion) 
		{
			case "Título":
                results = peliculas.Where(pelicula => pelicula.title.Contains(buscador.Text)).ToList();
                break;
			case "Idioma":
                results = peliculas.Where(pelicula => pelicula.original_language.Contains(buscador.Text)).ToList();
				break;
        }
        ObservableCollection<Pelicula> lista = new ObservableCollection<Pelicula>(results);

        listaPeliculas.ItemsSource = lista;
    }

    // Metodo con el picker
    private void pickerSeleccion(object sender, EventArgs e)
    {
        Picker picker = (Picker)sender;

        seleccion = picker.SelectedItem as String;
    }

    // Metodo en el que te preguna al usuario si quiere cerrar sesión
    private async void cerrarSesion(object sender, EventArgs e)
    {
        bool respuesta = await DisplayAlert("Cerrar Sesión", "¿Deseas cerrar sesión?", "Si", "No");
        if (respuesta) 
        {
            _ = cambiarLogin();
        }

    }

    private async void listarFavoritos(object sender, EventArgs e)
    {
       _= cambiarFavoritos();

    }

    private async Task cambiarLogin()
    {
        await AppShell.Current.GoToAsync(nameof(Login));
    }
    
    private async Task cambiarFavoritos()
    {
        await AppShell.Current.GoToAsync(nameof(FavoritosVista));
    }

    private void inicializarUsuario() 
    {
        int usuarioId = Preferences.Default.Get(App.usuario_id, -1);
        usuario = App.usuarioRepositorio.obtenerUsuario(usuarioId);
    }

    private void incializarFavoritos(ObservableCollection<Pelicula> pelis)
    {
        List<Favorito> listaF = App.favoritoRepositorio.listarFavoritos();

        foreach (Pelicula item in pelis)
        {
            if (listaF.FirstOrDefault(f => f.Pelicula_id == item.id && f.Usuario_id == usuario.Id) != null)
            {
                item.color = Color.FromRgba(255, 255, 0, 255);
            }
            else
            {
                item.color = Colors.Gray;
            }
        }
    }

}