using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.Core.BusinessLayer;
using Week7.Master.MVC.Helper;
using Week7.Master.MVC.Models;

namespace Week7.Master.MVC.Controllers
{
    public class CorsiController : Controller
    {
        private readonly IBusinessLayer BL;

        public CorsiController(IBusinessLayer bl)
        {
            BL = bl;
        }

        //CRUD su Corso

        //utl : https.../Corsi
        [HttpGet]
        public IActionResult Index()
        {
            var corsi = BL.GetAllCorsi();

            List<CorsoViewModel> corsiViewModel = new List<CorsoViewModel>();

            foreach(var item in corsi)
            {
                corsiViewModel.Add(item.toCorsoViewModel());
            }

            return View(corsiViewModel);
        }

        //url: https.../Corsi/Details/id
        [HttpGet("Corsi/Details/{code}")] //lo specifico visto che ho cod, se dovessi avere id non sarebbe necessario
        public IActionResult Details(string code)
        {
            var corso = BL.GetAllCorsi().FirstOrDefault(c=> c.CorsoCodice == code);
            var corsoViewModel = corso.toCorsoViewModel();

            return View(corsoViewModel);
        }
    }
}
