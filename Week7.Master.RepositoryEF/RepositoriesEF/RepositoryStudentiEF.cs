using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.Core.InterfaceRepositories;

namespace Week7.Master.RepositoryEF.RepositoriesEF
{
    public class RepositoryStudentiEF : IStudenteRepository
    {
        public Studente Add(Studente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Studenti.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Studente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Studenti.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Studente> Fetch()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Studenti.Include(s=> s.Corso).ToList();
            }
        }

        public List<Studente> FetchByCorso(Corso corsoEsistente)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Studenti.Include(s => s.Corso).Where(s=> s.CorsoCodice == corsoEsistente.CorsoCodice).ToList();
            }
        }

        public Studente GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Studenti.Include(s => s.Corso).FirstOrDefault(s=> s.Id == id);
            }
        }

        public Studente Update(Studente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Studenti.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
