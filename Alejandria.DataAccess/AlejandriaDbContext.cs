using Alejandria.Models;
using Microsoft.EntityFrameworkCore;

namespace Alejandria.DataAccess
{
    public class AlejandriaDbContext(DbContextOptions<AlejandriaDbContext> options) : DbContext(options)
    {
        public DbSet<Libro> Libros => Set<Libro>();
        public DbSet<Autor> Autores => Set<Autor>();
    }
}
