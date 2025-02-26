using NeohConcessionaria.Core.Entities;
using NeohConcessionaria.Infrastructure.Repositories.Fabricantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeohConcessionaria.Application.Services.FabricanteServices
{
    public class FabricanteService:IFabricanteService
    {
        private readonly IFabricanteRepository _fabricanteRepository;

        public FabricanteService(IFabricanteRepository fabricanteRepository)
        {
            _fabricanteRepository = fabricanteRepository;
        }
        public async Task<Fabricante> Create(Fabricante fabricante)
        {

            Fabricante fabricanteCreated = await _fabricanteRepository.Create(fabricante);
            return fabricanteCreated;
        }
        public async Task<List<Fabricante>> List()
        {
            List<Fabricante> Fabricantes = await _fabricanteRepository.GetAll();
            return Fabricantes;
        }
        public async Task<Fabricante> Details(int fabricanteId)
        {
            Fabricante Fabricantes = await _fabricanteRepository.Get(f=>f.FabricanteId==fabricanteId);
            return Fabricantes;
        }

        public async void Update(Fabricante Fabricante)
        {
            _fabricanteRepository.Update(Fabricante);
        }

        public async void Delete(int FabricanteId)
        {
            Fabricante fabricante = await _fabricanteRepository.Get(f => f.FabricanteId == FabricanteId);
            _fabricanteRepository.Delete(fabricante);
        }
    }
}
