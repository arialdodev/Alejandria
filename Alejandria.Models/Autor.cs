
namespace Alejandria.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Sexo { get; set; }

        public ICollection<Libro> Libros { get; } = [];
    }
}
