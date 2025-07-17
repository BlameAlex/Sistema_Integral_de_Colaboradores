using Microsoft.AspNetCore.Mvc;

namespace sic.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Dashboard() => View();
        public IActionResult Integracion() => View();
    }
}
