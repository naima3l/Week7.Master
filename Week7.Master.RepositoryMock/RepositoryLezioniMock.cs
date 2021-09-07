using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.Core.InterfaceRepositories;

namespace Week7.Master.RepositoryMock
{
    public class RepositoryLezioniMock : ILezioneRepository
    {
        public List<Lezione> Lezioni = new List<Lezione>();
        public Lezione Add(Lezione item)
        {
            var numLezioni = Lezioni.Count;
            item.LezioneId = numLezioni + 1;

            //FK e navigation property
            var corso = RepositoryCorsiMock.Corsi.FirstOrDefault(c => c.CorsoCodice == item.CorsoCodice);
            item.Corso = corso;
            corso.Lezioni.Add(item); //al corso aggiungo la lezione alle sua lista di lezioni

            var docente = RepositoryDocentiMock.Docenti.FirstOrDefault(d => d.Id == item.DocenteId);
            item.Docente = docente;
            docente.Lezioni.Add(item);

            Lezioni.Add(item);
            return item;
        }

        public bool Delete(Lezione item)
        {
            Lezioni.Remove(item);
            return true;
        }

        public List<Lezione> Fetch()
        {
            return Lezioni;
        }

        public List<Lezione> FetchByCorso(Corso corsoEsistente)
        {
            var lezioni = Lezioni.Where(l => l.CorsoCodice == corsoEsistente.CorsoCodice).ToList();

            return lezioni;
        }

        public Lezione GetById(int id)
        {
            return Lezioni.Find(l => l.LezioneId == id);
        }

        public Lezione Update(Lezione item)
        {
            var old = Lezioni.Find(l => l.LezioneId == item.LezioneId);
            old.Aula = item.Aula;
            return item;
        }
    }
}
