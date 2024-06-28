using Alejandria.Interfaces;
using Alejandria.Models;
using Alejandria.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Alejandria.web.Controllers
{
    public class LibroController(IServicesLibro serviceslibro, IAutorServices servicesautor) : Controller
    {
        private readonly IServicesLibro _serviceslibro = serviceslibro;
        private readonly IAutorServices _servicesautor = servicesautor; 

        [HttpGet]
        public async Task<IActionResult> Formulario(CrearLibroViewModel ViewModel)
        {
            try
            {
                ViewModel.Autores = await _servicesautor.Listar();
                return View(ViewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Error", new { messageError = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Libro libro)
        {
            try
            {
                await _serviceslibro.Crear(libro);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Error", new { messegeError = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Editar(Libro libro)
        {
            try
            {
                _serviceslibro.Editar(libro);
                return RedirectToAction("Formulario");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Error", new { messageError = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CrearEditar(CrearLibroViewModel ViewModel)
        {
            try
            {
                if (ViewModel.Libro.Id == 0)
                {
                    await _serviceslibro.Crear(ViewModel.Libro);
                }
                else
                {
                    await _serviceslibro.Editar(ViewModel.Libro);
                }
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Error", new { messageError = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int Id)
        {
            try
            {
                await _serviceslibro.Eliminar(Id);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Error", new { messageError = ex.Message });
            }
        }

        public async Task<IActionResult> Listar(BuscarAyLViewModel buscarAyLViewModel)
        {
            try
            {
                if (buscarAyLViewModel.BuscarNombre is null)
                {
                    IQueryable<Libro> libros = await _serviceslibro.Listar();
                    buscarAyLViewModel.Libros = libros;
                }
                else
                {
                    IQueryable<Libro> libros = await _serviceslibro.BuscarNombre(buscarAyLViewModel.BuscarNombre!);
                    buscarAyLViewModel.Libros = libros;
                }

                return View(buscarAyLViewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Error", new { messageError = ex.Message });
            }
        }
    }
}
