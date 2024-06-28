using Alejandria.Interfaces;
using Alejandria.Models;
using Alejandria.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Alejandria.web.Controllers
{
    public class AutorController(IAutorServices servicesAutor) : Controller
    {
        private readonly IAutorServices _servicesAutor = servicesAutor;
        [HttpGet]
        public IActionResult Formulario(Autor autor) => View(autor);

        [HttpPost]
        public async Task<IActionResult> Crear(Autor autor)
        {
            try
            {
                if (autor.Id == 0)
                {
                    await _servicesAutor.Crear(autor);
                }
                else
                {
                    await _servicesAutor.Editar(autor);
                }

                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Error", new { messageError = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Editar(Autor autor)
        {
            try
            {
                _servicesAutor.Editar(autor);
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
                await _servicesAutor.Eliminar(Id);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Error", new { menssegeError = ex.Message });
            }
        }

        public async Task<IActionResult> Listar(BuscarAyLViewModel buscarAyLViewModel)
        {
            try
            {
                if (buscarAyLViewModel.BuscarNombre is null)
                {
                    IQueryable<Autor> autores = await _servicesAutor.Listar();
                    buscarAyLViewModel.Autores = autores;
                }
                else
                {
                    IQueryable<Autor> autores = await _servicesAutor.BuscarNombre(buscarAyLViewModel.BuscarNombre!);
                    buscarAyLViewModel.Autores = autores;
                }
                return View(buscarAyLViewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Error", new { message = ex.Message });

            }
        }
    }
}
