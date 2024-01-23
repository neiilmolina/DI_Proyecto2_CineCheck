using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_DI.Modelo;

namespace Proyecto_DI.Repositorio
{
    public class UsuarioRepositorio
    {
        private String _ruta;
        private SQLiteConnection conexion;

        public UsuarioRepositorio(String ruta)
        {
            _ruta = ruta;
            conexion = new SQLiteConnection(ruta);

            // Escribo la ruta en la salida
            System.Diagnostics.Debug.WriteLine($"La ruta de la base de datos es: {_ruta}");
            // Creo la tabla si no existe
            if (!conexion.TableMappings.Any(e => e.MappedType.Name == "Usuario"))
            {
                conexion.CreateTable<Usuario>();
            }

        }

        public bool verUsuario(String nick, String password)
        {
            bool resultado = false;
            List<Usuario> lista = new List<Usuario>(listarUsuario());

            lista.ForEach(action => 
            {
                if (action.Nick.Equals(nick) && action.Password.Equals(password))
                {
                    resultado = true;
                }
            });
            return resultado;
        }

        public Usuario obtenerUsuario(int id)
        {
            Usuario usuario = new Usuario();   
            ObservableCollection<Usuario> listaUsuarios = listarUsuario();
            List<Usuario> lista = new List<Usuario>(listaUsuarios);

            int cont = 0;
            bool encontrado = false;

            while (cont <= lista.Count && !encontrado) 
            {
                if (lista[cont].Id == id) 
                {
                    usuario = lista[cont];
                    encontrado = true;
                } 
                else 
                {
                    cont++;
                }
            }

            return usuario;

        }

        public ObservableCollection<Usuario> listarUsuario()
        {
            List<Usuario> lista = conexion.Table<Usuario>().ToList();
            ObservableCollection<Usuario> listaUsuarios = new ObservableCollection<Usuario>(lista);
            return listaUsuarios;
        }

        // Añado usuario en la tabla usuario
        public void add(Usuario usuario)
        {
            conexion.Insert(usuario);
        }
    }
}
