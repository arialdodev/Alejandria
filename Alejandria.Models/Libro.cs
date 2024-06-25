
namespace Alejandria.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Idioma { get; set; }
        public string? Descripcion { get; set; }

        public int AutorId { get; set; }
        public Autor Autor { get; set; } = null!;
    }
}
