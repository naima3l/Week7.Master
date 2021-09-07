using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.Core.InterfaceRepositories;

namespace Week7.Master.RepositoryMock
{
    public class RepositoryDocentiMock : IDocenteRepository
    {
        public static List<Docente> Docenti = new List<Docente>()
        {
            new Docente{Id = 1, Nome = "Mario", Cognome = "Rossi",Email = "mario.rossi@gmail.com", Telefono = "3331234567"},
            new Docente{Id = 2, Nome = "Giuseppe", Cognome = "Neri",Email = "giuseppe.neri@gmail.com", Telefono = "3391234567"}
        };

        public Docente Add(Docente item)
        {
            var numDocenti = Docenti.Count;
            item.Id = numDocenti + 1;

            Docenti.Add(item);
            return item;
        }

        public bool Delete(Docente item)
        {
            Docenti.Remove(item);
            return true;
        }

        public List<Docente> Fetch()
        {
            return Docenti;
        }

        /*public Docente GetByData(string nome, string cognome, string email, string telefono)
        {
            return Docenti.FirstOrDefault(d => d.Nome == nome && d.Cognome == cognome && d.Email == email && d.Telefono == telefono);
        }*/

        public Docente GetById(int id)
        {
            return Docenti.Find(d => d.Id == id);
        }

        public Docente Update(Docente item)
        {
            var old = Docenti.Find(d => d.Id == item.Id);
            old.Nome = item.Nome;
            old.Cognome = item.Cognome;
            old.Email = item.Email;
            old.Telefono = item.Telefono;
            return item;
        }
    }
}
