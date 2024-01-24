using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_DI.Modelo
{
    public class Resultado
    {
        public int page { get; set; }
        public ObservableCollection<Pelicula> results { get; set; }
    }

    public class Pelicula
    {
        public int id { get; set; }
        public String title { get; set; }
        public String release_date { get; set; }
        public String original_language { get; set; }
        public float vote_average { get; set; }
        public String overview { get; set; }
    }

}
