namespace Proyecto_DI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Vistas.Lista), typeof(Vistas.Lista));
        Routing.RegisterRoute(nameof(Vistas.Login), typeof(Vistas.Login));
        Routing.RegisterRoute(nameof(Vistas.Registro), typeof(Vistas.Registro));
        Routing.RegisterRoute(nameof(Vistas.PaginaPrincipal), typeof(Vistas.PaginaPrincipal));
    }
}
