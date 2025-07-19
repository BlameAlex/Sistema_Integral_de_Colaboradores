using Microsoft.AspNetCore.Mvc;

namespace sic.Controllers
{
  public class AdminController : Controller
  {
    [HttpGet]
    public IActionResult Dashboard() => View();
    public IActionResult Busqueda() => View();
    public IActionResult CargasPendientes() => View();
    public IActionResult Notificaciones() => View();
    public IActionResult NuevoUsuario() => View();
    public IActionResult Configuracion() => View();
  }
}
