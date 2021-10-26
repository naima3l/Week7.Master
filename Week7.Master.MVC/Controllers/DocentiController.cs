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

        //add

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DocenteViewModel docenteViewModel)
        {
            if (ModelState.IsValid) //se la validazione è andata a buon fine, aggiungo alla lista e torno alla Index
            {
                BL.AggiungiDocente(docenteViewModel.toDocente());
                return RedirectToAction(nameof(Index)); //qui mi rimandi alla index
            }
            return View(docenteViewModel); //se non va a buon fine, ritorno 
        }

        //Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var docente = BL.GetAllDocenti().FirstOrDefault(d => d.Id == id);
            var docenteViewModel = docente.toDocenteViewModel();
            return View(docenteViewModel);
        }

        [HttpPost]
        public IActionResult Edit(DocenteViewModel docenteViewModel)
        {
            var docente = docenteViewModel.toDocente();

            if (ModelState.IsValid) //se la validazione è andata a buon fine, aggiungo alla lista e torno alla Index
            {
                BL.ModificaDocente(docenteViewModel.Id, docenteViewModel.Nome, docenteViewModel.Cognome, docenteViewModel.Email, docenteViewModel.Telefono);
                return RedirectToAction(nameof(Index)); //qui mi rimandi alla index
            }
            return View(docenteViewModel); //se non va a buon fine, ritorno 
        }

        //Delete
        public IActionResult Delete(int id)
        {
            var docente = BL.GetAllDocenti().FirstOrDefault(d => d.Id == id);
            var docenteViewModel = docente.toDocenteViewModel();
            return View(docenteViewModel);
        }

        [HttpPost]
        public IActionResult Delete(DocenteViewModel docenteViewModel)
        {
            var docente = docenteViewModel.toDocente();

            if (ModelState.IsValid) 
            {
                BL.DeleteDocenteById(docenteViewModel.Id);
                return RedirectToAction(nameof(Index));
            }
            return View(docenteViewModel);  
        }
    }
}
