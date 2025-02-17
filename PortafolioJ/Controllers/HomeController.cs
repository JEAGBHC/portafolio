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
        private readonly ServicioTransitorio servicioTransitorio;
        private readonly ServicioDelimitado servicioDelimitado;
        private readonly ServicioUnico servicioUnico;
        private readonly ServicioTransitorio servicioTransitorio2;
        private readonly ServicioDelimitado servicioDelimitado2;
        private readonly ServicioUnico servicioUnico2;

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos,
            ServicioTransitorio servicioTransitorio, ServicioDelimitado servicioDelimitado, ServicioUnico servicioUnico,
          ServicioTransitorio servicioTransitorio2, ServicioDelimitado servicioDelimitado2, ServicioUnico servicioUnico2)
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.servicioTransitorio = servicioTransitorio;
            this.servicioDelimitado = servicioDelimitado;
            this.servicioUnico = servicioUnico;
            this.servicioTransitorio = servicioTransitorio;
            this.servicioDelimitado = servicioDelimitado;
            this.servicioUnico = servicioUnico;
        }



        public IActionResult Index()
        {

            var proyectos= repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            var guidViewModel = new EjemploGUIDVIewModel() {

                Delimitado = servicioDelimitado.ObtenerGuid,
                Transitorio = servicioTransitorio.ObtenerGuid,
                Unico = servicioUnico.ObtenerGuid,

            };

            var Model =new HomeIndexViewModel() { Proyectos = proyectos,
            EjemploGUID_1 = guidViewModel};
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
