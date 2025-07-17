using Microsoft.AspNetCore.Mvc;

namespace sic.Controllers
{
  public class IntegracionController : Controller
  {
    [HttpGet]
    public IActionResult Inicio() => View();
    public IActionResult DatosGenerales() => View();
    public IActionResult FormacionAcademica() => View();
    public IActionResult ExperienciaLaboral() => View();
    public IActionResult ExperienciaDocente() => View();
    public IActionResult Conocimientos() => View();
    public IActionResult OtrosDatos() => View();
    public IActionResult AvisoPrivacidad() => View();

    [HttpPost] //SHIT AINT WORKING
    public IActionResult DatosGeneralesPost(string args) {
      return RedirectToAction("FormacionAcademica", "Integracion");
    }
    public IActionResult FormacionAcademicaPost(string args) {
      return RedirectToAction("ExperienciaLaboral", "Integracion");
    }
    public IActionResult ExperienciaLaboralPost(string args) {
      return RedirectToAction("ExperienciaDocente", "Integracion");
    }
    public IActionResult ExperienciaDocentePost(string args) {
      return RedirectToAction("Conocimientos", "Integracion");
    }
    public IActionResult ConocimientosPost(string args) {
      return RedirectToAction("OtrosDatos", "Integracion");
    }
    public IActionResult OtrosDatosPost(string args) {
      return RedirectToAction("AvisoPrivacidad", "Integracion");
    }
  } 
}
