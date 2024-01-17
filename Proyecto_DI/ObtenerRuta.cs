using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_DI
{
    public class ObtenerRuta
    {
        public static String devolverRuta(String nombreBaseDeDatos)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, nombreBaseDeDatos);
        }
    }
}
