using Microsoft.Extensions.Logging;
using Proyecto_DI.Repositorio;

namespace Proyecto_DI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        // Creo ruta
        String ruta = ObtenerRuta.devolverRuta("usuarios.db");
        builder.Services.AddSingleton<UsuarioRepositorio>(
        s => ActivatorUtilities.CreateInstance<UsuarioRepositorio>(s, ruta)
        );
        String rutaFavoritos = ObtenerRuta.devolverRuta("usuarios.db");

        builder.Services.AddSingleton<FavoritoRepositorio>(
        s => ActivatorUtilities.CreateInstance<FavoritoRepositorio>(s, rutaFavoritos)
        );

        return builder.Build();
    }
}
