using Microsoft.EntityFrameworkCore;
using NeohConcessionaria.Core.Entities;
using NeohConcessionaria.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NeohConcessionaria.Infrastructure.Repositories.Fabricantes
{
    public class FabricanteRepository : Repository<Fabricante>, IFabricanteRepository
    {
        private readonly AppDbContext _context;
        public FabricanteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Fabricante> Get(Expression<Func<Fabricante, bool>> predicate)
        {
            return await _context.Set<Fabricante>().Where(e => e.IsDeleted == false).Include(f => f.Veiculos).SingleOrDefaultAsync(predicate);
        }

        public async Task<List<Fabricante>> GetAll()
        {
            return await _context.Set<Fabricante>().Where(e => e.IsDeleted == false).Include(f=>f.Veiculos).ToListAsync();
        }
    }
}
