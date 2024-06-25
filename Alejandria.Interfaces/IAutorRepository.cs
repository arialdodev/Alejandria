using Alejandria.Models;

namespace Alejandria.Interfaces
{
    public interface IAutorRepository
    {
        public Task Crear(Autor autor);
        public Task Editar(Autor autor);
        public Task Eliminar(int Id);
        public Task<IQueryable<Autor>> Listar();
        public Task<IQueryable<Autor>> BuscarNombre(string nombre);
    }
}
