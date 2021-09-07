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
    public class RepositoryLezioniEF : ILezioneRepository
    {
        public Lezione Add(Lezione item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Lezioni.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Lezione item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Lezioni.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Lezione> Fetch()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Lezioni.Include(l => l.Corso).Include(l=> l.Docente).ToList();
            }
        }

        public List<Lezione> FetchByCorso(Corso corsoEsistente)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Lezioni.Include(l => l.Corso).Include(l => l.Docente).Where(l => l.CorsoCodice == corsoEsistente.CorsoCodice).ToList();
            }
        }

        public Lezione GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Lezioni.Include(l => l.Corso).Include(l => l.Docente).FirstOrDefault(l=> l.LezioneId == id);
            }
        }

        public Lezione Update(Lezione item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Lezioni.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
