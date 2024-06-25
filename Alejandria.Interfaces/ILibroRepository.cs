using Alejandria.Models;

namespace Alejandria.Interfaces
{
    public interface ILibroRepository
    {
        public Task Crear(Libro libro);
        public Task Editar(Libro libro);
        public Task Eliminar(int Id);
        public Task<IQueryable<Libro>> Listar();
        public Task<IQueryable<Libro>> BuscarNombre(string nombre);
    }
}
