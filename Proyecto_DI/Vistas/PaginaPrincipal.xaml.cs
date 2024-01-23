using Newtonsoft.Json;
using Proyecto_DI.Modelo;
using System.Collections.ObjectModel;

namespace Proyecto_DI.Vistas;

public partial class PaginaPrincipal : ContentPage
{
	private ObservableCollection<Pelicula> peliculas = new ObservableCollection<Pelicula>();
	private String seleccion;


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
        listaPeliculas.ItemsSource = results;
    }

    private void pickerSeleccion(object sender, EventArgs e)
    {
        Picker picker = (Picker)sender;

        seleccion = picker.SelectedItem as String;
    }

    private async Task cerrarSesionAsync(object sender, EventArgs e)
    {
        var resultado = await DisplayActionSheet("Ayuda", "Cancelar", null, "Si", "No");
        switch (resultado)
        {
            case "Si":
                {
                    await AppShell.Current.GoToAsync(nameof(Login));
                    break;
                }
        }
    }
}