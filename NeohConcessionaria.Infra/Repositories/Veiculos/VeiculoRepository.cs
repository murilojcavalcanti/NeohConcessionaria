using Microsoft.EntityFrameworkCore;
using NeohConcessionaria.Core.Entities;
using NeohConcessionaria.Infra.Persistence;
using NeohConcessionaria.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NeohConcessionaria.Infra.Repositories.Veiculos
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        private AppDbContext _context;
        public VeiculoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
                
        public async Task<Veiculo> Get(Expression<Func<Veiculo, bool>> predicate)
        {
            return await _context.Set<Veiculo>().Where(v => v.IsDeleted == false).SingleOrDefaultAsync(predicate);
        }

        public async Task<List<Veiculo>> GetAll()
        {
            return await _context.Veiculos.Where(v =>v.IsDeleted==false).Include(v=>v.Fabricante).ToListAsync();
        }

        public async Task<List<Veiculo>> GetPorFabricante(int FabricanteId)
        {
            return await _context.Set<Veiculo>().Where(v => v.IsDeleted == false && v.FabricanteId==FabricanteId).ToListAsync();
        }
    }
}
