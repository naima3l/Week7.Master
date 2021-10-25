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
                studentiViewModel.Add(item.toStudenteViewModel());
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
    }
}
