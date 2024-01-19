using Proyecto_DI.Repositorio;

namespace Proyecto_DI;

public partial class App : Application
{
    public static UsuarioRepositorio usuarioRepositorio { get; set; }


    public App(UsuarioRepositorio _usuarioRepositorio)
    {
        usuarioRepositorio = _usuarioRepositorio;

        InitializeComponent();

        MainPage = new AppShell();
    }

    // hacer un constructor en el que recoja los datos de la api
}
