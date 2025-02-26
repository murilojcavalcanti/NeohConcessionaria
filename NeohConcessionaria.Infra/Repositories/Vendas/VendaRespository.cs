using Microsoft.EntityFrameworkCore;
using NeohConcessionaria.Core.Entities;
using NeohConcessionaria.Infra.Persistence;
using NeohConcessionaria.Infrastructure.Repositories;
using System.Linq.Expressions;

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
            return await _context.Set<Venda>().Where(e => e.IsDeleted == false).Include(v=>v.Cliente).Include(v => v.Veiculo).Include(v => v.Concessionaria).SingleOrDefaultAsync(predicate);
        }

        public async Task<List<Venda>> GetAll()
        {
            return await _context.Set<Venda>().Where(e => e.IsDeleted == false).Include(v => v.Cliente).Include(v => v.Veiculo).ThenInclude(v=>v.Fabricante).Include(v => v.Concessionaria).ToListAsync();
        }
    }
}
