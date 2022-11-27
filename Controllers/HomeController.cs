using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Data;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models;
using System.Diagnostics;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Controllers
{
    public class HomeController : Controller
    {
        private readonly CineContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, CineContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        public IActionResult Index()
        {
            List<SelectListItem> listaDeGeneros = _context.Generos.ToList().ConvertAll(g =>
            {
                return new SelectListItem()
                {
                    Text = g.Nombre.ToString(),
                    Value = g.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.listaDeGeneros = listaDeGeneros;

            List<Pelicula> listaDePeliculas = _context.Peliculas.ToList();

            ViewBag.listaDePeliculas = listaDePeliculas;

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