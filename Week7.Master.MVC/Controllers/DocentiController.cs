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
    public class DocentiController : Controller
    {
        private readonly IBusinessLayer BL;

        public DocentiController(IBusinessLayer bl)
        {
            BL = bl;
        }
        public IActionResult Index()
        {
            var docenti = BL.GetAllDocenti();
            List<DocenteViewModel> docentiViewModel = new List<DocenteViewModel>();

            foreach (var item in docenti)
            {
                docentiViewModel.Add(item.toDocenteViewModel());
            }
            return View(docentiViewModel);
        }

        [HttpGet] //lo specifico visto che ho cod, se dovessi avere id non sarebbe necessario
        public IActionResult Details(int id)
        {
            var docente = BL.GetAllDocenti().FirstOrDefault(d => d.Id == id);
            var docenteViewModel = docente.toDocenteViewModel();

            return View(docenteViewModel);
        }
    }
}
