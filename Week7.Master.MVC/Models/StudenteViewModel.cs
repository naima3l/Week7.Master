using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week7.Master.MVC.Models
{
    public class StudenteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascita { get; set; }
        public string TitoloStudio { get; set; }


        //FK
        public string CorsoCodice { get; set; }
        //navigation property verso il corso
        public CorsoViewModel Corso { get; set; }
    }
}
