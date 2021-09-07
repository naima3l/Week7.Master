using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.Master.Core.Entities
{
    public class Studente : Persona
    {
        public DateTime DataNascita { get; set; }
        public string TitoloStudio { get; set; }

        //FK
        public string CorsoCodice { get; set; }
        //navigation property verso il corso
        public Corso Corso { get; set; }

        public override string ToString()
        {
            return $"Id : {Id}\t{Nome}\t{Cognome}\tnato il {DataNascita.ToShortDateString()}\tAltre info : {Email} - {TitoloStudio}";
        }
    }
}
