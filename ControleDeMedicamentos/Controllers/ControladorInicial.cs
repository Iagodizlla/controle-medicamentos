using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.Controllers;

[Route("/")]
public class ControladorInicial : Controller
{
    [HttpGet]
    public IActionResult PaginaInicial()
    {
        return View();
    }
}