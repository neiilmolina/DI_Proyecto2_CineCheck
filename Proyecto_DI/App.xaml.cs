using Proyecto_DI.Repositorio;
using System.Windows.Input;

namespace Proyecto_DI;

public partial class App : Application
{
    public static UsuarioRepositorio usuarioRepositorio { get; set; }
    public static FavoritoRepositorio favoritoRepositorio { get; set; }
   
    public static String usuario_id = "usuario_id";
    public static List<int> peliculas_id = new List<int>();

    public ICommand linkedinGesture => new Command<string>(async (url) => await Launcher.OpenAsync(url));

    public App(UsuarioRepositorio _usuarioRepositorio, FavoritoRepositorio _favoritoRepositorio)
    {
        usuarioRepositorio = _usuarioRepositorio;
        favoritoRepositorio = _favoritoRepositorio;

        InitializeComponent();
        BindingContext = this;
        MainPage = new AppShell();

    }

    private void inicializarUsuario()
    {
        int usuarioId = Preferences.Default.Get(App.usuario_id, -1);
        var usuario = App.usuarioRepositorio.obtenerUsuario(usuarioId);
        

    }

}
