using SQLite;

namespace Proyecto_DI.Modelo
{
    [Table("Favorito")]
    public class Favorito
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Usuario_id { get; set; }
        
        public int Pelicula_id { get; set; }
    }
}
