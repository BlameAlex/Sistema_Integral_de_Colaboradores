using Microsoft.AspNetCore.Mvc;

namespace sic.Controllers
{
  public class IntegracionController : Controller
  {
    public IActionResult Inicio() => View();
    public IActionResult DatosGenerales() => View();
    public IActionResult FormacionAcademica() => View();
    public IActionResult ExperienciaLaboral() => View();
    public IActionResult ExperienciaDocente() => View();
    public IActionResult Conocimientos() => View();
    public IActionResult OtrosDatos() => View();
    public IActionResult AvisoPrivacidad() => View();

    [HttpPost] //SHIT AINT WORKING
    public IActionResult DatosGenerales(string args) {
      return RedirectToAction("FormacionAcademica", "Integracion");
    }
    public IActionResult FormacionAcademica(string args) {
      return RedirectToAction("ExperienciaLaboral", "Integracion");
    }
    public IActionResult ExperienciaLaboral(string args) {
      return RedirectToAction("ExperienciaDocente", "Integracion");
    }
    public IActionResult ExperienciaDocente(string args) {
      return RedirectToAction("Conocimientos", "Integracion");
    }
    public IActionResult Conocimientos(string args) {
      return RedirectToAction("OtrosDatos", "Integracion");
    }
    public IActionResult OtrosDatos(string args) {
      return RedirectToAction("AvisoPrivacidad", "Integracion");
    }
  } 
}
