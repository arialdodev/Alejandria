using Microsoft.AspNetCore.Mvc;

namespace Alejandria.web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error(string mensajeError)
        {
            return View("Error", mensajeError);
        }
    }
}
