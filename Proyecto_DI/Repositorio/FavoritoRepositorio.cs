using System.Collections.ObjectModel;
using Proyecto_DI.Modelo;
using SQLite;

namespace Proyecto_DI.Repositorio
{
    public class FavoritoRepositorio
    {
        private String _ruta;
        private SQLiteConnection conexion;

        public FavoritoRepositorio(String ruta)
        {
            _ruta = ruta;
            conexion = new SQLiteConnection(ruta);

            // Escribo la ruta en la salida
            System.Diagnostics.Debug.WriteLine($"La ruta de la base de datos es: {_ruta}");
            // Creo la tabla si no existe
            if (!conexion.TableMappings.Any(e => e.MappedType.Name == "Favorito"))
            {
                conexion.CreateTable<Favorito>();
            }

        }

        // Recoger datos 
        public List<Favorito> listarFavoritos() 
        {
            List<Favorito> lista = conexion.Table<Favorito>().ToList();
            return lista;
        }

        // Filtrar por id usuario
        public List<Favorito> filtrarPorUsuario(int usuarioId) 
        {
            List<Favorito> lista = listarFavoritos().Where(favortito => favortito.Usuario_id == usuarioId).ToList();
            return lista;
        }

        // Mirar si el id de la pelicula esta en la lista filtrada por usuarios
        public bool verPeliculaUsuario(int usuarioId, int peliculaId) 
        {
            List<Favorito> lista = filtrarPorUsuario(usuarioId);

            int cont = 0;
            bool encontrado = false;

            if (lista.Count != 0) 
            {
                while (cont <= lista.Count && !encontrado)
                {
                    if (lista[cont].Pelicula_id == peliculaId)
                    {
                        encontrado = true;
                    }
                    else
                    {
                        cont++;
                    }
                }
            }

            return encontrado;
        }

        
        // Devolver un objeto favorito
        public Favorito devolverFavorito(int usuarioId, int peliculaId) 
        {
            Favorito favorito = null;
            List<Favorito> lista = listarFavoritos();

            int cont = 0;
            bool encontrado = false;

            while (cont <= lista.Count && !encontrado)
            {
                if (lista[cont].Usuario_id == usuarioId && lista[cont].Pelicula_id == peliculaId)
                {
                    favorito = lista[cont];
                    encontrado = true;
                }
                else
                {
                    cont++;
                }
            }

            return favorito;


        }

        // Añadir 
        public void add(Favorito item) 
        {
            conexion.Insert(item);
        }

        // Eliminar
        public void delete(int usuarioId, int peliculaId) 
        {
            conexion.Table<Favorito>().Where(f => f.Usuario_id == usuarioId && f.Pelicula_id == peliculaId).Delete();
        }
    }
}
