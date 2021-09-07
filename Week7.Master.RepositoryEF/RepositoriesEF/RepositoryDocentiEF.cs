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
    public class RepositoryDocentiEF : IDocenteRepository
    {
        public Docente Add(Docente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Docenti.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Docente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Docenti.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Docente> Fetch()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Docenti.Include(d=> d.Lezioni).ToList();
            }
        }

        public Docente GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Docenti.Include(d => d.Lezioni).FirstOrDefault(d=> d.Id == id);
            }
        }

        public Docente Update(Docente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Docenti.Remove(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
