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
            List<StudenteViewModel> studentiViewModel = new List<StudenteViewModel>();
            foreach (var item in corso.Studenti)
            {
                studentiViewModel.Add(item.toStudenteViewModel());
            }

            return new CorsoViewModel
            {
                CorsoCodice = corso.CorsoCodice,
                Nome = corso.Nome,
                Descrizione = corso.Descrizione,
                Studenti = studentiViewModel
            };
        }

        public static Corso toCorso(this CorsoViewModel corsoViewModel)
        {
            List<Studente> studenti = new List<Studente>();
            foreach (var item in corsoViewModel.Studenti)
            {
                studenti.Add(item?.toStudente());
            }
            return new Corso
            {
                CorsoCodice = corsoViewModel.CorsoCodice,
                Nome = corsoViewModel.Nome,
                Descrizione = corsoViewModel.Descrizione,
                Studenti = studenti,
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

        public static Docente toDocente(this DocenteViewModel docenteViewModel)
        {
            return new Docente
            {
                Id = docenteViewModel.Id,
                Nome = docenteViewModel.Nome,
                Cognome = docenteViewModel.Cognome,
                Email = docenteViewModel.Email,
                Telefono = docenteViewModel.Telefono
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
                TitoloStudio = studente.TitoloStudio,
                CorsoCodice = studente.CorsoCodice
            };
        }

        public static Studente toStudente(this StudenteViewModel studenteViewModel)
        {
            return new Studente
            {
                Id = studenteViewModel.Id,
                Nome = studenteViewModel.Nome,
                Cognome = studenteViewModel.Cognome,
                DataNascita = studenteViewModel.DataNascita,
                Email = studenteViewModel.Email,
                TitoloStudio = studenteViewModel.TitoloStudio,
                CorsoCodice = studenteViewModel.CorsoCodice
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
