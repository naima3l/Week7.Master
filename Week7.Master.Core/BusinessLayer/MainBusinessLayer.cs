using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.Core.InterfaceRepositories;

namespace Week7.Master.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        //Dichiaro quali sono i repository che ho a disposizione
        private readonly ICorsoRepository corsiRepo;
        private readonly IStudenteRepository studentiRepo;
        private readonly IDocenteRepository docentiRepo;
        private readonly ILezioneRepository lezioniRepo;

        public MainBusinessLayer(ICorsoRepository corsi,IStudenteRepository studenti, IDocenteRepository docenti, ILezioneRepository lezioni)
        {
            corsiRepo = corsi;
            studentiRepo = studenti;
            docentiRepo = docenti;
            lezioniRepo = lezioni;
        }

        public string DeleteByCode(string codiceCorsoDaEliminare)
        {
            var corsoEsistente = corsiRepo.GetByCode(codiceCorsoDaEliminare);
            if (corsoEsistente == null)
            {
                return "Errore : codice corso non presente";
            }
            if(corsoEsistente.Lezioni.Count !=0)
            {
                return "Errore : il corso non può essere rimosso perchè associato a delle lezioni ancora attive";
            }
            if (corsoEsistente.Studenti.Count != 0)
            {
                return "Errore : il corso non può essere rimosso perchè associato a degli studenti";
            }
            bool esito = corsiRepo.Delete(corsoEsistente);
            if(esito == false)
            {
                return "C'è stato un errore nella rimozione del corso";
            }
            return "Il corso è stato eliminato correttamente";
        }

        #region Funzionalità corsi
        public List<Corso> GetAllCorsi()
        {
            return corsiRepo.Fetch();
        }

        public string InserisciNuovoCorso(Corso newCorso)
        {
            //controllo input
            //non deve esister un altro corso con lo stesso codice
            var corsoEsistente = corsiRepo.GetByCode(newCorso.CorsoCodice);
            if(corsoEsistente != null)
            {
                return "Errore : codice corso già presente";
            }
            corsiRepo.Add(newCorso);
            return "Il corso è stato aggiunto correttamente";
        }

        public string ModificaCorso(string codiceCorsoDaModificare, string nomeDaModifcare, string descrizioneDaModificare)
        {
            var corsoEsistente = corsiRepo.GetByCode(codiceCorsoDaModificare);
            if (corsoEsistente == null)
            {
                return "Errore : codice corso non presente";
            }
            corsoEsistente.Nome = nomeDaModifcare;
            corsoEsistente.Descrizione = descrizioneDaModificare;
            corsiRepo.Update(corsoEsistente);
            return "Il corso è stato aggiornato correttamente";
        }
        #endregion

        #region Funzionalità studenti
        public List<Studente> GetAllStudenti()
        {
            return studentiRepo.Fetch();
        }

        public string AggiungiStudente(Studente studente)
        {
            //controllo input
            var corsoEsistente = corsiRepo.GetByCode(studente.CorsoCodice);
            if (corsoEsistente == null)
            {
                return "Errore : codice corso non presente";
            }
            studentiRepo.Add(studente);
            return "Studente aggiunto con successo";
        }

        public string ModificaStudente(int id, string nome, string cognome, DateTime dataNascita, string titolo, string email, string codiceCorso)
        {
            var studenteEsistente = studentiRepo.GetById(id);
            if(studenteEsistente == null)
            {
                return "Errore : lo studente inserito non esiste";
            }

            studenteEsistente.Nome = nome;
            studenteEsistente.Cognome = cognome;
            studenteEsistente.DataNascita = dataNascita;
            studenteEsistente.TitoloStudio = titolo;
            studenteEsistente.Email = email;
            studenteEsistente.CorsoCodice = codiceCorso;

            studentiRepo.Update(studenteEsistente);
            return "Studente aggiornato con successo";
        }

        public string DeleteStudentById(int id)
        {
            var studenteEsistente = studentiRepo.GetById(id);
            if (studenteEsistente == null)
            {
                return "Errore : lo studente inserito non esiste";
            }

            studentiRepo.Delete(studenteEsistente);
            return "Studente eliminato correttamente";
        }

        public List<Studente> VisualizzaStudentiCorso(string codice)
        {
            var corsoEsistente = corsiRepo.GetByCode(codice);
            if(corsoEsistente == null)
            {
                return null;
            }

            var studentiCorso = studentiRepo.FetchByCorso(corsoEsistente);

            return studentiCorso;
        }

        #endregion

        #region Funzionalità Docenti

        public List<Docente> GetAllDocenti()
        {
            return docentiRepo.Fetch();
        }

        public string AggiungiDocente(Docente docente)
        {
            //var docenteEsistente = docentiRepo.GetByData(docente.Nome, docente.Cognome, docente.Email, docente.Telefono); //metodo alternativo
            var docenteEsistente = docentiRepo.Fetch().FirstOrDefault(d => d.Nome == docente.Nome && d.Cognome == docente.Cognome && d.Email == docente.Email && d.Telefono == docente.Telefono);
            if(docenteEsistente != null)
            {
                return "Errore : esiste già un docente con gli stessi dati";
            }
            docentiRepo.Add(docente);
            return "Docente aggiunto con successo";
        }

        public string ModificaDocente(int id, string nome, string cognome, string email, string telefono)
        {
            var docenteEsistente = docentiRepo.GetById(id);
            if (docenteEsistente == null)
            {
                return "Errore : il docente inserito non esiste";
            }

            docenteEsistente.Nome = nome;
            docenteEsistente.Cognome = cognome;
            docenteEsistente.Email = email;
            docenteEsistente.Telefono = telefono;

            docentiRepo.Update(docenteEsistente);
            return "Docente aggiornato con successo";
        }

        public string DeleteDocenteById(int id)
        {
            var docenteEsistente = docentiRepo.GetById(id);
            if (docenteEsistente == null)
            {
                return "Errore : il docente inserito non esiste";
            }
            if(docenteEsistente.Lezioni.Count != 0)
            {
                return "Errore : il docente non può essere rimosso perchè è già associato a una lezione";
            }
            docentiRepo.Delete(docenteEsistente);
            return "Il docente è stato rimosso correttamente";
        }

        #endregion

        #region Funzionalità Lezioni


        public List<Lezione> GetAllLezioni()
        {
            return lezioniRepo.Fetch();

        }

        public string InserisciNuovaLezione(Lezione lezione)
        {
            var corsoEsistente = corsiRepo.GetByCode(lezione.CorsoCodice);
            if (corsoEsistente == null)
            {
                return "Errore : codice corso non presente";
            }
            var docenteEsistente = docentiRepo.GetById(lezione.DocenteId);
            if(docenteEsistente == null)
            {
                return "Errore : id docente non presente";
            }

            lezioniRepo.Add(lezione);
            return "Lezione aggiunta con successo";
        }

        public string ModificaAulaLezioneById(int id, string aula)
        {
            var old = lezioniRepo.GetById(id);
            if(old == null)
            {
                return "Errore : lezione non esiste";
            }
            old.Aula = aula;
            lezioniRepo.Update(old);
            return "Lezione aggiornata con successo";
        }

        public string EliminaLezioneById(int id)
        {
            var old = lezioniRepo.GetById(id);
            if (old == null)
            {
                return "Errore : lezione non esiste";
            }
            
            if(old.Corso !=null)
            {
                return "Errore: la lezione non può essere eliminata perchè associata ad un corso esistente";
            }
            if(old.Docente != null)
            {
                return "Errore: la lezione non può essere eliminata perchè associata ad un docente esistente";
            }
            lezioniRepo.Update(old);
            return "Lezione aggiornata con successo";
        }

        public List<Lezione> VisualizzaLezioniCorso(string codice)
        {
            var corsoEsistente = corsiRepo.GetByCode(codice);
            if (corsoEsistente == null)
            {
                return null;
            }

            var lezioniCorso = lezioniRepo.FetchByCorso(corsoEsistente);

            return lezioniCorso;
        }

        public List<Lezione> VisualizzaLezioniCorsoConNome(string nome)
        {
            var corsoEsistente = corsiRepo.GetByName(nome);
            if (corsoEsistente == null)
            {
                return null;
            }

            var lezioniCorso = lezioniRepo.FetchByCorso(corsoEsistente);

            return lezioniCorso;
        }
        #endregion

    }
}
