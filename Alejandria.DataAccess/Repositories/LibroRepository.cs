using Alejandria.Interfaces;
using Alejandria.Models;
using Microsoft.EntityFrameworkCore;

namespace Alejandria.DataAccess.Repositories
{
    public class LibroRepository(AlejandriaDbContext alejandriaDbContext) : ILibroRepository
    {
        private readonly AlejandriaDbContext _alejandriaDbContext = alejandriaDbContext;
        public async Task Crear(Libro libro)
        {
            await _alejandriaDbContext.Libros.AddAsync(libro);
            await _alejandriaDbContext.SaveChangesAsync();
        }

        public async Task Editar(Libro libro)
        {
            if (libro.Id is not 0)
            {
                _alejandriaDbContext.Libros.Update(libro);
                await _alejandriaDbContext.SaveChangesAsync();
            }
        }

        public async Task Eliminar(int Id)
        {
            Libro? libro = await _alejandriaDbContext.Libros
                .FirstOrDefaultAsync(libro => libro.Id == Id);
            if (libro is not null)
            {
                _alejandriaDbContext.Libros.Remove(libro);
                _alejandriaDbContext.SaveChanges();
            }
        }

        public Task<IQueryable<Libro>> Listar()
        {
            IQueryable<Libro> libro = _alejandriaDbContext.Libros;
            return Task.FromResult(libro);
        }

        public async Task<IQueryable<Libro>> BuscarNombre(string nombre)
        {
            IQueryable<Libro> libros = _alejandriaDbContext.Libros;

            if (!string.IsNullOrEmpty(nombre))
            {
                IQueryable<Libro> librosTemp = _alejandriaDbContext.Libros
                    .Where(libro => libro.Nombre!.Contains(nombre));
                libros = librosTemp;
            }
            return await Task.FromResult(libros);
        }
    }
}
