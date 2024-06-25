using Alejandria.Interfaces;
using Alejandria.Models;
using Microsoft.EntityFrameworkCore;

namespace Alejandria.DataAccess.Repositories
{
    public class AutorRepository(AlejandriaDbContext alejandriaDbContext) : IAutorRepository
    {
        private readonly AlejandriaDbContext _alejandriaDbContext = alejandriaDbContext;

        public async Task Crear(Autor autor)
        {
            await _alejandriaDbContext.Autores.AddAsync(autor);
            await _alejandriaDbContext.SaveChangesAsync();
        }
        public async Task Editar(Autor autor)
        {

            if (autor.Id is not 0)
            {
                _alejandriaDbContext.Autores.Update(autor);
                await _alejandriaDbContext.SaveChangesAsync();
            }
        }

        public async Task Eliminar(int Id)
        {
            Autor? autor = await _alejandriaDbContext.Autores
               .FirstOrDefaultAsync(autor => autor.Id == Id);

            if (autor is not null)
            {
                _alejandriaDbContext.Autores.Remove(autor);
                await _alejandriaDbContext.SaveChangesAsync();
            }
        }

        public Task<IQueryable<Autor>> Listar()
        {
            IQueryable<Autor> autores = _alejandriaDbContext.Autores;
            return Task.FromResult(autores);
        }
        public async Task<IQueryable<Autor>> BuscarNombre(string nombre)
        {
            IQueryable<Autor> autores = _alejandriaDbContext.Autores;

            if (!string.IsNullOrEmpty(nombre))
            {
                IQueryable<Autor> autoresTemp = _alejandriaDbContext.Autores
                    .Where(autor => autor.Nombre!.Contains(nombre));
                autores = autoresTemp;
            }
            return await Task.FromResult(autores);
        }
    }
}
