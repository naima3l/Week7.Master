using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;

namespace Week7.Master.Core.InterfaceRepositories
{
    public interface IDocenteRepository : IRepository<Docente>
    {
        public Docente GetById(int id);
        //public Docente GetByData(string nome, string cognome, string email, string telefono);
    }
}
