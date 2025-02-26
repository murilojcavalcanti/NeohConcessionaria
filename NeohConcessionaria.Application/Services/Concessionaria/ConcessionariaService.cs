using NeohConcessionaria.Infra.Repositories.Concessionarias;
using NeohConcessionaria.Core.Entities;
using NeohConcessionaria.Application.Services.ConcessionariaService;

namespace NeohConcessionaria.Application.Services.ConcessionariaServices
{
    public class ConcessionariaService:IConcessionariaService
    {

        private readonly IConcessionariaRepository _ConcessionariaRepository;

        public ConcessionariaService(IConcessionariaRepository ConcessionariaRepository)
        {
            _ConcessionariaRepository = ConcessionariaRepository;
        }
        public async Task<Concessionaria> Create(Concessionaria Concessionaria)
        {
                Concessionaria concessionaria =  await _ConcessionariaRepository.Create(Concessionaria);
                return concessionaria;   
        }
        public async  Task<List<Concessionaria>> List()
        {
            List<Concessionaria> Concessionarias = await _ConcessionariaRepository.GetAll();
            
            return Concessionarias;
        }
        public async Task<Concessionaria> Details(int ConcessionariaId)
        {
            Concessionaria concessionaria = await _ConcessionariaRepository.Get(c => c.ConcessionariaId == ConcessionariaId);

            return concessionaria;
        }
        
        public async void Update(Concessionaria Concessionaria)
        {
                _ConcessionariaRepository.Update(Concessionaria);
        }

        public async void Delete(int ConcessionariaId)
        {
            await _ConcessionariaRepository.Get(f => f.ConcessionariaId == ConcessionariaId);
        }
    }
}
