using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.Core.InterfaceRepositories;

namespace Week7.Master.RepositoryMock
{
    public class RepositoryStudentiMock : IStudenteRepository
    {
        public static List<Studente> Studenti = new List<Studente>();
        public Studente Add(Studente item)
        {
            var numStudenti = Studenti.Count;
            item.Id = numStudenti + 1;

            //FK e navigation property
            var corso = RepositoryCorsiMock.Corsi.FirstOrDefault(c => c.CorsoCodice == item.CorsoCodice);
            item.Corso = corso;
            corso.Studenti.Add(item); //al corso aggiungo lo studente alla sua lista studenti
            
            Studenti.Add(item);
            return item;
        }

        public bool Delete(Studente item)
        {
            Studenti.Remove(item);
            return true;
        }

        public List<Studente> Fetch()
        {
            return Studenti;
        }

        public List<Studente> FetchByCorso(Corso corsoEsistente)
        {
            var stud = Studenti.Where(s => s.CorsoCodice == corsoEsistente.CorsoCodice).ToList();

            return stud;
        }

        public Studente GetById(int id)
        {
            return Studenti.Find(s => s.Id == id);
        }

        public Studente Update(Studente item)
        {
            var old = Studenti.Find(s => s.Id == item.Id);
            old.Nome = item.Nome;
            old.Cognome = item.Cognome;
            old.CorsoCodice = item.CorsoCodice;
            old.DataNascita = item.DataNascita;
            old.Email = item.Email;
            old.TitoloStudio = item.TitoloStudio;
            return item;
        }
    }
}
