using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week7.Master.MVC.Models
{
    public class LezioneViewModel
    {
        public int LezioneId { get; set; }
        public DateTime DataOraInizio { get; set; }
        public int Durata { get; set; }
        public string Aula { get; set; }
    }
}
