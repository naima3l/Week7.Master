using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.MVC.Models;

namespace Week7.Master.MVC.Controllers
{
    [Authorize] // richiede login/autenticazione per effettuare tutte le azioni del controller ad eccezione delle [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous] //disponibile anche senza login/autenticazione
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]// richiede login/autenticazione per effettuare la singola azione
        [Route("Home/Esempi")]
        public IActionResult Prova()
        {
            //ViewBag
            ViewBag.Messaggio = "Benevenuti nella pagina. Questo è il messaggio contenuto nella view bag";
            ViewBag.Valore = 123;

            //ViewData
            ViewData["MessaggioVD"] = "Benevenuti anche da parte del ViewData";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
