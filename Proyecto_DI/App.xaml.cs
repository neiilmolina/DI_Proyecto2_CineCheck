using Proyecto_DI.Repositorio;

namespace Proyecto_DI;

public partial class App : Application
{
    public static UsuarioRepositorio usuarioRepositorio { get; set; }
    public static String usuario_id = "usuario_id";


    public App(UsuarioRepositorio _usuarioRepositorio)
    {
        usuarioRepositorio = _usuarioRepositorio;

        InitializeComponent();

        MainPage = new AppShell();
    }
}
