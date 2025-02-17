using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortafolioJ.Models;
using PortafolioJ.servicios;


namespace PortafolioJ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;
    

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos)

        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            
        }



        public IActionResult Index()
        {
            _logger.LogInformation("Este es un msj del futuro");
            var proyectos= repositorioProyectos.ObtenerProyectos().Take(3).ToList();


            var Model = new HomeIndexViewModel()
            {
                Proyectos = proyectos

            };
            return View(Model);
        }

        public IActionResult Proyectos() 
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }

        [HttpGet]
        public IActionResult Contacto()
        {

            return View();

        }
        [HttpPost]
        public IActionResult Contacto(ContactoViewModel contactoViewModel)
        {

            return RedirectToAction("Gracias");

        }

        public IActionResult Gracias()
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
