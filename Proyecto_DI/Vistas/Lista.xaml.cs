namespace Proyecto_DI.Vistas;

public partial class Lista : ContentPage
{
	public Lista()
	{
		InitializeComponent();
        lista.ItemsSource = App.usuarioRepositorio.listarUsuario();
    }
}