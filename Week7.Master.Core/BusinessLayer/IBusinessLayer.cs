using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;

namespace Week7.Master.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        //Aggiungere "l'elenco" delle funzionalità richieste dalla traccia

        #region Funzionalità corsi
        //Visualizza corsi
        public List<Corso> GetAllCorsi();

        //Inserire un nuovo corso
        public string InserisciNuovoCorso(Corso newCorso);

        //Modifica corso
        public string ModificaCorso(string codiceCorsoDaModificare, string nomeDaModifcare, string descrizioneDaModificare);
        public string DeleteByCode(string codiceCorsoDaEliminare);
        #endregion
        #region Funzionalità studenti
        public List<Studente> GetAllStudenti();
        public string AggiungiStudente(Studente studente);
        public string ModificaStudente(int id, string nome, string cognome, DateTime dataNascita, string titolo, string email, string codiceCorso);
        public string DeleteStudentById(int id);
        public List<Studente> VisualizzaStudentiCorso(string codice);
        #endregion
        #region Funzionalità Docenti
        public List<Docente> GetAllDocenti();
        public string AggiungiDocente(Docente docente);
        public string ModificaDocente(int id, string nome, string cognome, string email, string telefono);
        public string DeleteDocenteById(int id);
        #endregion
        #region Funzionalità Lezioni

        public List<Lezione> GetAllLezioni();
        public string InserisciNuovaLezione(Lezione lezione);
        public string ModificaAulaLezioneById(int id, string aula);
        public string EliminaLezioneById(int id);
        public List<Lezione> VisualizzaLezioniCorso(string codice);
        public List<Lezione> VisualizzaLezioniCorsoConNome(string nome);
        #endregion
    }
}
