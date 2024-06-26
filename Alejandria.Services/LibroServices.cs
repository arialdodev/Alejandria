using Alejandria.Models;
using Alejandria.Interfaces;

namespace Alejandria.Services
{
    public class LibroServices(ILibroRepository libroRepository) : IServicesLibro
    {
        private readonly ILibroRepository _libroRepository = libroRepository;
        public Task Crear(Libro libro) => _libroRepository.Crear(libro);
        public Task Editar(Libro libro) => _libroRepository.Editar(libro);
        public Task Eliminar(int Id) => _libroRepository.Eliminar(Id);
        public Task<IQueryable<Libro>> Listar() => _libroRepository.Listar();
        public Task<IQueryable<Libro>> BuscarNombre(string nombre) => _libroRepository.BuscarNombre(nombre);
    }
}
