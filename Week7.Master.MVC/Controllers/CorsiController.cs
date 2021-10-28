using Microsoft.AspNetCore.Authorization;
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

        //add
        [Authorize(Policy = "Adm")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "Adm")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator        
        [HttpPost]
        public IActionResult Create(CorsoViewModel corsoViewModel)
        {
            if(ModelState.IsValid) //se la validazione è andata a buon fine, aggiungo alla lista e torno alla Index
            {
                BL.InserisciNuovoCorso(corsoViewModel.toCorso());
                return RedirectToAction(nameof(Index)); //qui mi rimandi alla index
            }
            return View(corsoViewModel); //se non va a buon fine, ritorno 
        }

        //Edit
        [Authorize(Policy = "Adm")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator        
        [HttpGet("Corsi/Edit/{code}")]
        public IActionResult Edit(string code)
        {
            var corso = BL.GetAllCorsi().FirstOrDefault(c => c.CorsoCodice == code);
            var corsoViewModel = corso.toCorsoViewModel();
            return View(corsoViewModel);
        }

        [Authorize(Policy = "Adm")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator        
        [HttpPost("Corsi/Edit/{code}")]
        public IActionResult Edit(CorsoViewModel corsoViewModel)
        {
            var corso = corsoViewModel.toCorso();

            if (ModelState.IsValid) //se la validazione è andata a buon fine, aggiungo alla lista e torno alla Index
            {
                BL.ModificaCorso(corso.CorsoCodice,corso.Nome,corso.Descrizione);
                return RedirectToAction(nameof(Index)); //qui mi rimandi alla index
            }
            return View(corsoViewModel); //se non va a buon fine, ritorno 
        }

        //Delete
        [Authorize(Policy = "Adm")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator        
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var corso = BL.GetAllCorsi().FirstOrDefault(c => c.CorsoCodice == id);
            var corsoViewModel = corso.toCorsoViewModel();
            return View(corsoViewModel);
        }

        [Authorize(Policy = "Adm")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator        
        [HttpPost]
        public IActionResult Delete(CorsoViewModel corsoViewModel)
        {
            var corso = corsoViewModel.toCorso();

            if (ModelState.IsValid) //se la validazione è andata a buon fine, aggiungo alla lista e torno alla Index
            {
                BL.DeleteByCode(corso.CorsoCodice);
                return RedirectToAction(nameof(Index)); //qui mi rimandi alla index
            }
            return View(corsoViewModel); //se non va a buon fine, ritorno 
        }
    }
}
