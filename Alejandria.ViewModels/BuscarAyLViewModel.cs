using Alejandria.Models;

namespace Alejandria.ViewModels
{
    public class BuscarAyLViewModel
    {
        public IQueryable<Autor> Autores { get; set; }
        public string? BuscarNombre { get; set; }
        public IQueryable<Libro> Libros { get; set; }
    }
}
