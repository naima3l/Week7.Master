using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.Core.BusinessLayer;
using Week7.Master.MVC.Helper;
using Week7.Master.MVC.Models;

namespace Week7.Master.MVC.Controllers
{
    [Authorize(Policy = "Adm")]
    public class StudentiController : Controller
    {
        private readonly IBusinessLayer BL;

        public StudentiController(IBusinessLayer bl)
        {
            BL = bl;
        }
        public IActionResult Index()
        {
            var studenti = BL.GetAllStudenti();
            List<StudenteViewModel> studentiViewModel = new List<StudenteViewModel>();

            foreach (var item in studenti)
            {
                studentiViewModel.Add(item?.toStudenteViewModel());
            }
            return View(studentiViewModel);
        }

        [HttpGet] 
        public IActionResult Details(int id)
        {
            var studente = BL.GetAllStudenti().FirstOrDefault(s=> s.Id == id);
            var studenteViewModel = studente.toStudenteViewModel();

            return View(studenteViewModel);
        }

        //add

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudenteViewModel studenteViewModel)
        {
            if (ModelState.IsValid) //se la validazione è andata a buon fine, aggiungo alla lista e torno alla Index
            {
                var studente = studenteViewModel.toStudente();
                //studente.CorsoCodice = "C-01";
                BL.AggiungiStudente(studente);
                return RedirectToAction(nameof(Index)); //qui mi rimandi alla index
            }
            return View(studenteViewModel); //se non va a buon fine, ritorno 
        }

        //Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var studente = BL.GetAllStudenti().FirstOrDefault(s => s.Id == id);
            var studenteViewModel = studente.toStudenteViewModel();
            return View(studenteViewModel);
        }

        [HttpPost]
        public IActionResult Edit(StudenteViewModel studenteViewModel)
        {
            var studente = studenteViewModel.toStudente();

            if (ModelState.IsValid) //se la validazione è andata a buon fine, aggiungo alla lista e torno alla Index
            {
                BL.ModificaStudente(studenteViewModel.Id, studenteViewModel.Nome, studenteViewModel.Cognome, studenteViewModel.DataNascita, studenteViewModel.TitoloStudio, studenteViewModel.Email, studenteViewModel.CorsoCodice);
                return RedirectToAction(nameof(Index)); //qui mi rimandi alla index
            }
            return View(studenteViewModel); //se non va a buon fine, ritorno 
        }

        //Delete
        public IActionResult Delete(int id)
        {
            var studente = BL.GetAllStudenti().FirstOrDefault(s => s.Id == id);
            var studenteViewModel = studente.toStudenteViewModel();
            return View(studenteViewModel);
        }

        [HttpPost]
        public IActionResult Delete(StudenteViewModel studenteViewModel)
        {
            var studente = studenteViewModel.toStudente();

            if (ModelState.IsValid)
            {
                BL.DeleteStudentById(studenteViewModel.Id);
                return RedirectToAction(nameof(Index));
            }
            return View(studenteViewModel);
        }

        [HttpGet]
        public IActionResult DeleteJS(int id)
        {
            var messaggio = BL.DeleteStudentById(id);
            if (messaggio == "Studente eliminato correttamente")
            {
                return Json(true);
            }

            return Json(false);
        }
        private void LoadViewBag()
        {
            ViewBag.TitoloStudio = new SelectList(new[]{
                new { Value="D", Text="Diploma"},
                new { Value="L", Text="Laurea"} }.OrderBy(x => x.Text), "Value", "Text");
        }
    }
}
