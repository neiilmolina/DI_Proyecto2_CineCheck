namespace Proyecto_DI.Vistas;

public partial class Login : ContentPage
{

    private bool usuarioEncontrado = VistaModelo.LoginVM.usuarioEncontrado;
	public Login()
	{
		InitializeComponent();

	}

    public async void iniciarSesion(object sender, EventArgs e)
    {
        String mensaje = "";
        if (usuarioEncontrado)
        {
            mensaje = "Inicio de sesi�n con exito";
        }
        else 
        {
            mensaje = "No existe ese usuario";
        }
        await DisplayAlert("Iniciar Sesi�n", mensaje, "Ok");

    }

    
}