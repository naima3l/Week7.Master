using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.Master.Core.Entities
{
    public class Lezione
    {
        public int LezioneId { get; set; }
        public DateTime DataOraInizio { get; set; }
        public int Durata { get; set; }
        public string Aula { get; set; }

        //FK verso Docente
        public string CorsoCodice { get; set; }
        public Docente Docente { get; set; }
        //FK verso Corso
        public int DocenteId { get; set; }
        public Corso Corso { get; set; }

        public override string ToString()
        {
            return $"Lezione : {LezioneId}\tDate e ora : {DataOraInizio}\tDurata in giorni : {Durata}\tAula : {Aula}\nDocente : {Docente.ToString()}\nCorso : {Corso.ToString()}";
        }
    }
}
