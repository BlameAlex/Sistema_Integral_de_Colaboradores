using Microsoft.AspNetCore.Mvc;

namespace sic.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult Dashboard() => View();
        public IActionResult Expediente() => View();
        public IActionResult CargarArchivos() => View();
        public IActionResult Notificaciones() => View();
        public IActionResult Configuracion() => View();
    }
}
