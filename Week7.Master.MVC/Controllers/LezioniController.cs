using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.Core.BusinessLayer;
using Week7.Master.MVC.Models;
using Week7.Master.MVC.Helper;

namespace Week7.Master.MVC.Controllers
{
    public class LezioniController : Controller
    {
        private readonly IBusinessLayer BL;

        public LezioniController(IBusinessLayer bl)
        {
            BL = bl;
        }
        public IActionResult Index()
        {
            var lezioni = BL.GetAllLezioni();
            List<LezioneViewModel> lezioniViewModel = new List<LezioneViewModel>();

            foreach (var item in lezioni)
            {
                lezioniViewModel.Add(item.toLezioneViewModel());
            }
            return View(lezioniViewModel);
        }
    }
}
