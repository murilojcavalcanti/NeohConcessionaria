using NeohConcessionaria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeohConcessionaria.Application.Services.FabricanteServices
{
    public interface IFabricanteService
    {
        Task<Fabricante> Create(Fabricante fabricante);
        Task<List<Fabricante>> List();
        Task<Fabricante> Details(int fabricanteId);
        void Update(Fabricante Fabricante);
        void Delete(int FabricanteId);
    }
}
