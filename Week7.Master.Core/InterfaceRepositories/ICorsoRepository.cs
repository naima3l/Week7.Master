﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;

namespace Week7.Master.Core.InterfaceRepositories
{
    public interface ICorsoRepository : IRepository<Corso>
    {
        public Corso GetByCode(string code);
        public Corso GetByName(string nome);
    }
}
