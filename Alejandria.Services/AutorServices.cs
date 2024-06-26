using Alejandria.Interfaces;
using Alejandria.Models;

namespace Alejandria.Services
{
    public class AutorServices(IAutorRepository autorRepository) : IAutorServices
    {
        private readonly IAutorRepository _autorRepository = autorRepository;

        public Task Crear(Autor autor) => _autorRepository.Crear(autor);
        public Task Editar(Autor autor) => _autorRepository.Editar(autor);
        public Task Eliminar(int Id) => _autorRepository.Eliminar(Id);
        public Task<IQueryable<Autor>> Listar() => _autorRepository.Listar();
        public Task<IQueryable<Autor>> BuscarNombre(string nombre)
            => _autorRepository.BuscarNombre(nombre);

    }
}
