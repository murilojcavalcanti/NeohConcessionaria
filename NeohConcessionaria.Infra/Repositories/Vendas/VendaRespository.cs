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

namespace NeohConcessionaria.Infra.Repositories.Vendas
{
    public class VendaRespository : Repository<Venda>, IVendaRepository
    {
        private readonly AppDbContext _context;
        public VendaRespository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Venda> Get(Expression<Func<Venda, bool>> predicate)
        {
            return await _context.Set<Venda>().Where(e => e.IsDeleted == false).Include(v=>v.Concessionaria).SingleOrDefaultAsync(predicate);
        }

        public async Task<List<Venda>> GetAll()
        {
            return await _context.Set<Venda>().Where(e => e.IsDeleted == false).Include(v => v.Concessionaria).ToListAsync();
        }
    }
}
