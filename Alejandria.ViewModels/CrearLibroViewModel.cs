using Alejandria.Models;

namespace Alejandria.ViewModels
{
    public class CrearLibroViewModel
    {
        public IQueryable Autores { get; set; }
        public Autor Autor { get; set; }
        public Libro Libro { get; set; }
    }
}
