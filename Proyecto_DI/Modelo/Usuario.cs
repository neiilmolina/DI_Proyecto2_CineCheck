using SQLite;

namespace Proyecto_DI.Modelo
{
    [Table("Usuario")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public String Nick { get; set; }

        public String Nombre { get; set; }

        public int Edad { get; set; }

        public String Password { get; set; }
    }
}
