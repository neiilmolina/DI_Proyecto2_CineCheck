using Newtonsoft.Json;
using Proyecto_DI.Modelo;
using System.Collections.ObjectModel;

namespace Proyecto_DI.Vistas;

public partial class PaginaPrincipal : ContentPage
{
	private ObservableCollection<Pelicula> peliculas = new ObservableCollection<Pelicula>();


    public PaginaPrincipal()
	{
		InitializeComponent();
		consultaHttp();
	}

	private async void consultaHttp()
	{
		String host = "https://api.themoviedb.org/3/discover/movie?api_key=0bba8bfe2dc15305ae2e105a8003ce7a";
		
		HttpClient httpClient= new HttpClient();

		String respuesta =  await httpClient.GetStringAsync(host);

        Resultado resultado = JsonConvert.DeserializeObject<Resultado>(respuesta);

        peliculas = resultado.results;

		actualizarLista();

	}

	private void actualizarLista ()
	{
		listaPeliculas.ItemsSource = peliculas;
    }

    private void buscarPeliculas(object sender, EventArgs e)
    {
        List<Pelicula> results = peliculas.Where(cadena => cadena.title.Contains(buscador.Text)).ToList();
		ObservableCollection<Pelicula> lista = new ObservableCollection<Pelicula>(results);
        listaPeliculas.ItemsSource = results;
    }
}