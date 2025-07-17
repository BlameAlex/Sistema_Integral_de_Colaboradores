using Microsoft.AspNetCore.Mvc;

namespace sic.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(string username, string password)
        {
            // TODO: Lógica de autenticación
            return RedirectToAction("Inicio", "Integracion");
        }
    }
}
