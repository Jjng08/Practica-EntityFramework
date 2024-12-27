using System.Diagnostics;
using AspNetCoreGeneratedDocument;
using ClaseNosePeroClase.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClaseNosePeroClase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult Vista(string nombre, string email, string mensaje, string opciones)
        {
            ViewBag.nombre = nombre;
            ViewBag.email = email;
            ViewBag.mensaje = mensaje;
            ViewBag.opcionSeleccionada = opciones;
            return View("/Views/Home/vista.cshtml");
        }
        [HttpGet]
        public IActionResult vista() 
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
