using Microsoft.AspNetCore.Mvc;

namespace Alejandria.web.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult Index() => View();
    }
}
