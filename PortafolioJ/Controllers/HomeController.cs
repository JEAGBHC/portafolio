using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortafolioJ.Models;
using PortafolioJ.servicios;

namespace PortafolioJ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        public IActionResult Index()
        {
            var repositorioProyectos = new RespositorioProyectos();
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            var Model =new HomeIndexViewModel() { Proyectos = proyectos };
            return View(Model);
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
