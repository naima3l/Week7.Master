using System;
using System.Collections.Generic;
using Week7.Master.Core.BusinessLayer;
using Week7.Master.Core.Entities;
using Week7.Master.RepositoryEF.RepositoriesEF;
//using Week7.Master.RepositoryMock;

namespace Week7.Master
{
    class Program
    {
        //private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryCorsiMock(), new RepositoryStudentiMock(), new RepositoryDocentiMock(), new RepositoryLezioniMock());
        private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryCorsiEF(), new RepositoryStudentiEF(), new RepositoryDocentiEF(), new RepositoryLezioniEF());
        static void Main(string[] args)
        {
            bool continua = true;
            while(continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }


        private static int SchermoMenu()
        {
            Console.WriteLine("******************Menu****************");
            //Funzionalità su Corsi
            Console.WriteLine("\nFunzionalità CORSI");
            Console.WriteLine("1. Visualizza Corsi");
            Console.WriteLine("2. Inserisci nuovo Corso");
            Console.WriteLine("3. Modifica Corso");
            Console.WriteLine("4. Elimina Corso");
            //Funzionalità su Docenti
            Console.WriteLine("\nFunzionalità Docenti");
            Console.WriteLine("5. Visualizza Docenti");
            Console.WriteLine("6. Inserisci nuovo Docente");
            Console.WriteLine("7. Modifica Docente");
            Console.WriteLine("8. Elimina Docente");
            //Funzionalità su Lezioni
            Console.WriteLine("\nFunzionalità Lezioni");
            Console.WriteLine("9. Visualizza elenco delle lezioni completo");
            Console.WriteLine("10. Inserimento nuova lezione");
            Console.WriteLine("11. Modifica lezione");//per semplicità solo modifica Aula
            Console.WriteLine("12. Elimina lezione");
            Console.WriteLine("13. Visualizza le Lezioni di un Corso ricercando per Codice del Corso");
            Console.WriteLine("14. Visualizza le Lezioni di un Corso ricercando per Nome del Corso");
            //Funzionalità su Studenti
            Console.WriteLine("\nFunzionalità Studenti");
            Console.WriteLine("15. Visualizza l'elenco completo degli studenti");
            Console.WriteLine("16. Inserimento nuovo Studente");
            Console.WriteLine("17. Modifica Studente");//per semplicità solo email
            Console.WriteLine("18. Elimina Studente");
            Console.WriteLine("19. Visualizza l'elenco degli studenti iscritti ad un corso");

            //Exit
            Console.WriteLine("\n0. Exit");
            Console.WriteLine("********************************************");


            int scelta;
            Console.Write("Inserisci scelta: ");
            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 19)
            {
                Console.Write("\nScelta errata. Inserisci scelta corretta: ");
            }
            return scelta;


        }
        
        private static bool AnalizzaScelta(int scelta)
        {
            switch(scelta)
            {
                case 1:
                    VisualizzaCorsi();
                    break;
                case 2:
                    InserisciNuovoCorso();
                    break;
                case 3:
                    ModificaCorso();
                    break;
                case 4:
                    EliminaCorso();
                    break;
                case 5:
                    VisualizzaDocenti();
                    break;
                case 6:
                    InserisciNuovoDocente();
                    break;
                case 7:
                    ModificaDocente();
                    break;
                case 8:
                    EliminaDocente();
                    break;
                case 9:
                    VisualizzaLezioni();
                    break;
                case 10:
                    InserisciNuovaLezione();
                    break;
                case 11:
                    ModificaAulaLezione();
                    break;
                case 12:
                    EliminaLezione();
                    break;
                case 13:
                    VisualizzaLezioniConCodiceCorso();
                    break;
                case 14:
                    VisualizzaLezioniConNomeCorso();
                    break;
                case 15:
                    VisualizzaStudenti();
                    break;
                case 16:
                    InserisciNuovoStudente();
                    break;
                case 17:
                    ModificaStudente();
                    break;
                case 18:
                    EliminaStudente();
                    break;
                case 19:
                    VisualizzaStudentiCorso();
                    break;
                case 0:
                    return false;
            }
            return true;
        }

        private static void VisualizzaLezioniConNomeCorso()
        {
            Console.WriteLine("Ecco l'elenco dei corsi");
            VisualizzaCorsi();
            Console.WriteLine("Di quale corso vuoi visualizzare le lezioni? Inserisci il nome");
            string nome = Console.ReadLine();
            while (String.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Inserisci un nome valido!");
            }

            var lezioni = bl.VisualizzaLezioniCorsoConNome(nome);
            if (lezioni == null || lezioni.Count == 0)
            {
                Console.WriteLine($"Nessuna lezione nel corso {nome}");
            }
            else
            {
                Console.WriteLine($"Le lezioni del corso {nome} sono : ");
                foreach (var item in lezioni)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void VisualizzaLezioniConCodiceCorso()
        {
            Console.WriteLine("Ecco l'elenco dei corsi");
            VisualizzaCorsi();
            Console.WriteLine("Di quale corso vuoi visualizzare le lezioni? Inserisci il codice");
            string codice = Console.ReadLine();
            while (String.IsNullOrEmpty(codice))
            {
                Console.WriteLine("Inserisci un codice valido!");
            }

            var lezioni = bl.VisualizzaLezioniCorso(codice);
            if (lezioni == null || lezioni.Count == 0)
            {
                Console.WriteLine($"Nessuna lezione nel corso {codice}");
            }
            else
            {
                Console.WriteLine($"Le lezioni del corso {codice} sono : ");
                foreach (var item in lezioni)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void EliminaLezione()
        {
            Console.WriteLine("Inserisci l'id della lezione che vuoi modificare");
            VisualizzaLezioni();
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) || id < 0)
            {
                Console.WriteLine("Id non valido. Riprova");
            }

            string esito = bl.EliminaLezioneById(id);
            Console.WriteLine(esito);
        }

        private static void ModificaAulaLezione()
        {
            Console.WriteLine("Inserisci l'id della lezione che vuoi modificare");
            VisualizzaLezioni();
            int id;
            while(!int.TryParse(Console.ReadLine(), out id) || id < 0)
            {
                Console.WriteLine("Id non valido. Riprova");
            }
            Console.WriteLine("Inserisci l'aula");
            string aula = Console.ReadLine();
            while (String.IsNullOrEmpty(aula))
            {
                Console.WriteLine("Inserisci un'aula valida!");
            }
            string esito = bl.ModificaAulaLezioneById(id, aula);
            Console.WriteLine(esito);
        }

        private static void InserisciNuovaLezione()
        {
            Console.WriteLine("Inserisci data e ora inizio della nuova lezione");
            DateTime dataOra = new DateTime();
            while(!DateTime.TryParse(Console.ReadLine(),out dataOra))
            {
                Console.WriteLine("Data e ora non validi. Riprova");
            }
            Console.WriteLine("Inserisci la durata in giorni");
            int durata;
            while(!int.TryParse(Console.ReadLine(), out durata) || durata <= 0)
            {
                Console.WriteLine("Durata non valida! Riprova");
            }
            Console.WriteLine("Inserisci l'aula della lezione");
            string aula = Console.ReadLine();
            while (String.IsNullOrEmpty(aula))
            {
                Console.WriteLine("Inserisci un'aula valida!");
            }
            Console.WriteLine("Inserisci il codice del corso della lezione, tra questi");
            VisualizzaCorsi();
            string codice = Console.ReadLine();
            while (String.IsNullOrEmpty(codice))
            {
                Console.WriteLine("Inserisci un codice valido!");
            }
            Console.WriteLine("Inserisci l'id del docente che terrà la lezione");
            VisualizzaDocenti();
            int idDocente;
            while(!int.TryParse(Console.ReadLine(), out idDocente) || idDocente < 0)
            {
                Console.WriteLine("Id docente errato. Riprova");
            }
            

            Lezione lezione = new Lezione();
            lezione.Aula = aula;
            lezione.DataOraInizio = dataOra;
            lezione.Durata = durata;
            lezione.CorsoCodice = codice;
            lezione.DocenteId = idDocente;

            string esito = bl.InserisciNuovaLezione(lezione);
            Console.WriteLine(esito);
        }

        private static void VisualizzaLezioni()
        {
            var lezioni = bl.GetAllLezioni();
            if (lezioni.Count == 0)
            {
                Console.WriteLine("Nessuna lezione disponibile");
            }
            else
            {
                Console.WriteLine("Le lezioni sono : ");
                foreach (var item in lezioni)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void EliminaDocente()
        {
            Console.WriteLine("Ecco l'elenco dei docenti");
            VisualizzaDocenti();
            Console.WriteLine("Quale docente vuoi eliminare? Inserisci il suo Id");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) || id < 0)
            {
                Console.WriteLine("Id non valido. Riprova!");
            }

            string esito = bl.DeleteDocenteById(id);
            Console.WriteLine(esito);
        }

        private static void ModificaDocente()
        {
            Console.WriteLine("Ecco l'elenco dei docenti");
            VisualizzaDocenti();
            Console.WriteLine("Quale docente vuoi modificare? Inserisci il suo Id");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) || id < 0)
            {
                Console.WriteLine("Id non valido. Riprova!");
            }

            Console.WriteLine("Modifica nome");
            string nome = Console.ReadLine();
            while (String.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Inserisci un nome valido!");
            }
            Console.WriteLine("Modifica cognome");
            string cognome = Console.ReadLine();
            while (String.IsNullOrEmpty(cognome))
            {
                Console.WriteLine("Inserisci un cognome valido!");
            }
            Console.WriteLine("Modifica email");
            string email = Console.ReadLine();
            while (String.IsNullOrEmpty(email))
            {
                Console.WriteLine("Inserisci un' email valida!");
            }
            Console.WriteLine("Modifica numero di telefono");
            string telefono = Console.ReadLine();
            while (String.IsNullOrEmpty(telefono))
            {
                Console.WriteLine("Inserisci un numero di telefono valido!");
            }

            string esito = bl.ModificaDocente(id, nome, cognome,email, telefono);
            Console.WriteLine(esito);

        }

        private static void InserisciNuovoDocente()
        {
            Console.WriteLine("Inserisci nome");
            string nome = Console.ReadLine();
            while (String.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Inserisci un nome valido!");
            }
            Console.WriteLine("Inserisci cognome");
            string cognome = Console.ReadLine();
            while (String.IsNullOrEmpty(cognome))
            {
                Console.WriteLine("Inserisci un cognome valido!");
            }
            Console.WriteLine("Inserisci email");
            string email = Console.ReadLine();
            while (String.IsNullOrEmpty(email))
            {
                Console.WriteLine("Inserisci un'email valida!");
            }
            Console.WriteLine("Inserisci numero di telefono");
            string telefono = Console.ReadLine();
            while (String.IsNullOrEmpty(telefono))
            {
                Console.WriteLine("Inserisci un numero di telefono valido!");
            }


            Docente docente = new Docente();
            docente.Nome = nome;
            docente.Cognome = cognome;
            docente.Email = email;
            docente.Telefono = telefono;

            string esito = bl.AggiungiDocente(docente);
            Console.WriteLine(esito);
        }

        private static void VisualizzaDocenti()
        {
            var docenti = bl.GetAllDocenti();
            if (docenti.Count == 0)
            {
                Console.WriteLine("Nessun docente disponibile");
            }
            else
            {
                Console.WriteLine("I docenti sono : ");
                foreach (var item in docenti)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void VisualizzaStudentiCorso()
        {
            Console.WriteLine("Ecco l'elenco dei corsi");
            VisualizzaCorsi();
            Console.WriteLine("Di quale corso vuoi visualizzare gli studenti? Inserisci il codice");
            string codice = Console.ReadLine();
            while (String.IsNullOrEmpty(codice))
            {
                Console.WriteLine("Inserisci un codice valido!");
            }

            var studenti = bl.VisualizzaStudentiCorso(codice);
            if (studenti == null || studenti.Count == 0)
            {
                Console.WriteLine($"Nessuno studente iscritto al corso {codice}");
            }
            else
            {
                Console.WriteLine($"Gli studenti del corso {codice} sono : ");
                foreach (var item in studenti)
                {
                    Console.WriteLine(item.ToString());
                }
            }


        }
        private static void EliminaStudente()
        {
            Console.WriteLine("Ecco l'elenco degli studenti");
            VisualizzaStudenti();
            Console.WriteLine("Quale studente vuoi eliminare? Inserisci il suo Id");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) || id < 0)
            {
                Console.WriteLine("Id non valido. Riprova!");
            }

            string esito = bl.DeleteStudentById(id);
            Console.WriteLine(esito);
        }
        private static void ModificaStudente()
        {
            Console.WriteLine("Ecco l'elenco degli studenti");
            VisualizzaStudenti();
            Console.WriteLine("Quale studente vuoi modificare? Inserisci il suo Id");
            int id;
            while(!int.TryParse(Console.ReadLine(), out id) || id < 0)
            {
                Console.WriteLine("Id non valido. Riprova!");
            }
            Console.WriteLine("Modifica nome");
            string nome = Console.ReadLine();
            while (String.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Inserisci un nome valido!");
            }
            Console.WriteLine("Modifica cognome");
            string cognome = Console.ReadLine();
            while (String.IsNullOrEmpty(cognome))
            {
                Console.WriteLine("Inserisci un cognome valido!");
            }
            Console.WriteLine("Modifica la data di nascita");
            DateTime dataNascita = new DateTime();
            while (!DateTime.TryParse(Console.ReadLine(), out dataNascita))
            {
                Console.WriteLine("Data non valida. Riprova");
            }
            Console.WriteLine("Modifica email");
            string email = Console.ReadLine();
            while (String.IsNullOrEmpty(email))
            {
                Console.WriteLine("Inserisci un'email valida!");
            }
            Console.WriteLine("Modifica titoli di studio");
            string titolo = Console.ReadLine();
            while (String.IsNullOrEmpty(titolo))
            {
                Console.WriteLine("Inserisci un titolo di studio valido!");
            }
            Console.WriteLine("Modifica codice corso a cui si vuole iscrivere");
            string codiceCorso = Console.ReadLine();
            while (String.IsNullOrEmpty(codiceCorso))
            {
                Console.WriteLine("Inserisci un codice corso valido!");
            }

            string esito = bl.ModificaStudente(id, nome, cognome, dataNascita, titolo, email, codiceCorso);
            Console.WriteLine(esito);
        }

        private static void InserisciNuovoStudente()
        {
            Console.WriteLine("Inserisci nome");
            string nome = Console.ReadLine();
            while (String.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Inserisci un nome valido!");
            }
            Console.WriteLine("Inserisci cognome");
            string cognome = Console.ReadLine();
            while (String.IsNullOrEmpty(cognome))
            {
                Console.WriteLine("Inserisci un cognome valido!");
            }
            Console.WriteLine("Inserisci la data di nascita");
            DateTime dataNascita = new DateTime();
            while(!DateTime.TryParse(Console.ReadLine(), out dataNascita))
            {
                Console.WriteLine("Data non valida. Riprova");
            }
            Console.WriteLine("Inserisci email");
            string email = Console.ReadLine();
            while (String.IsNullOrEmpty(email))
            {
                Console.WriteLine("Inserisci un'email valida!");
            }
            Console.WriteLine("Inserisci titoli di studio");
            string titolo = Console.ReadLine();
            while (String.IsNullOrEmpty(titolo))
            {
                Console.WriteLine("Inserisci un titolo di studio valido!");
            }
            Console.WriteLine("Inserisci codice corso a cui si vuole iscrivere");
            string codiceCorso = Console.ReadLine();
            while (String.IsNullOrEmpty(codiceCorso))
            {
                Console.WriteLine("Inserisci un codice corso valido!");
            }

            Studente studente = new Studente();
            studente.Nome = nome;
            studente.Cognome = cognome;
            studente.Email = email;
            studente.DataNascita = dataNascita;
            studente.TitoloStudio = titolo;
            studente.CorsoCodice = codiceCorso;

            string esito =  bl.AggiungiStudente(studente);
            Console.WriteLine(esito);

        }

        private static void VisualizzaStudenti()
        {
            var studenti = bl.GetAllStudenti();
            if (studenti.Count == 0)
            {
                Console.WriteLine("Nessuno studente disponibile");
            }
            else
            {
                Console.WriteLine("Gli studenti sono : ");
                foreach (var item in studenti)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void EliminaCorso()
        {
            Console.WriteLine("Ecco l'elenco dei corsi disponibili");
            VisualizzaCorsi();
            Console.WriteLine("Quale corso vuoi eliminare?");
            string codice = Console.ReadLine();
            while (String.IsNullOrEmpty(codice))
            {
                Console.WriteLine("Inserisci un codice valido!");
            }

            string esito = bl.DeleteByCode(codice);
            Console.WriteLine(esito);
        }

        private static void ModificaCorso()
        {
            Console.WriteLine("Ecco l'elenco dei corsi disponibili");
            VisualizzaCorsi();
            Console.WriteLine("Quale corso vuoi modifcare?");
            string codice = Console.ReadLine();
            while (String.IsNullOrEmpty(codice))
            {
                Console.WriteLine("Inserisci un codice valido!");
            }
            Console.WriteLine("Modifica il nome del corso");
            string nome = Console.ReadLine();
            while (String.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Inserisci un nome valido!");
            }
            Console.WriteLine("Modifica la descrizione del corso");
            string descrizione = Console.ReadLine();
            while (String.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Inserisci una descrizione valida!");
            }

            string esito = bl.ModificaCorso(codice, nome, descrizione);
            Console.WriteLine(esito);
        }

        private static void InserisciNuovoCorso()
        {
            //Chiedo all'utente i dati per creare il corso
            Console.WriteLine("Inserisci il codice del nuovo corso");
            string codice = Console.ReadLine();
            while (String.IsNullOrEmpty(codice))
            {
                Console.WriteLine("Inserisci un codice valido!");
            }
            Console.WriteLine("Inserisci il nome del nuovo corso");
            string nome = Console.ReadLine();
            while (String.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Inserisci un nome valido!");
            }
            Console.WriteLine("Inserisci la descrizione del nuovo corso");
            string descrizione = Console.ReadLine();
            while (String.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Inserisci una descrizione valida!");
            }

            //lo creo
            Corso nuovoCorso = new Corso();
            nuovoCorso.CorsoCodice = codice;
            nuovoCorso.Nome = nome;
            nuovoCorso.Descrizione = descrizione;

            //lo passo al business layer per controllare i dati e aggiungerlo al "DB"
            string esito = bl.InserisciNuovoCorso(nuovoCorso);
            //stampo il messaggio
            Console.WriteLine(esito);
        }

        private static void VisualizzaCorsi()
        {
            var corsi = bl.GetAllCorsi();
            if(corsi.Count == 0)
            {
                Console.WriteLine("Nessun corso disponibile");
            }
            else
            {
                Console.WriteLine("I corsi disponibili sono : ");
                foreach (var item in corsi)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }
}
