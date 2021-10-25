using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.MVC.Models;

namespace Week7.Master.MVC.Helper
{
    public static class Mapping
    {
        public static CorsoViewModel toCorsoViewModel(this Corso corso)
        {
            return new CorsoViewModel
            {
                CorsoCodice = corso.CorsoCodice,
                Nome = corso.Nome,
                Descrizione = corso.Descrizione
            };
        }

        public static Corso toCorso(this CorsoViewModel corsoViewModel)
        {
            return new Corso
            {
                CorsoCodice = corsoViewModel.CorsoCodice,
                Nome = corsoViewModel.Nome,
                Descrizione = corsoViewModel.Descrizione
                //Studenti = null,
                //Lezioni = null
            };
        }

        public static DocenteViewModel toDocenteViewModel(this Docente docente)
        {
            return new DocenteViewModel
            {
                Id = docente.Id,
                Nome = docente.Nome,
                Cognome = docente.Cognome,
                Email = docente.Email,
                Telefono = docente.Telefono
            };
        }

        public static StudenteViewModel toStudenteViewModel(this Studente studente)
        {
            return new StudenteViewModel
            {
                Id = studente.Id,
                Nome = studente.Nome,
                Cognome = studente.Cognome,
                DataNascita = studente.DataNascita,
                Email = studente.Email,
                TitoloStudio = studente.TitoloStudio
            };
        }

        public static LezioneViewModel toLezioneViewModel(this Lezione lezione)
        {
            return new LezioneViewModel
            {
                LezioneId = lezione.LezioneId,
                Aula = lezione.Aula,
                DataOraInizio = lezione.DataOraInizio,
                Durata = lezione.Durata
            };
        }
    }
}
