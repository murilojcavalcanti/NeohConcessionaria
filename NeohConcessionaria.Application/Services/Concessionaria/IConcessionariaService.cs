using NeohConcessionaria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeohConcessionaria.Application.Services.ConcessionariaService
{
    public interface IConcessionariaService
    {
        Task<Concessionaria> Create(Concessionaria Concessionaria);
        Task<List<Concessionaria>> List();
        Task<Concessionaria> Details(int ConcessionariaId);
        void Update(Concessionaria Concessionaria);
        void Delete(int ConcessionariaId);
    }
}
