using Microsoft.EntityFrameworkCore;
using NeohConcessionaria.Core.Entities;
using NeohConcessionaria.Infra.Persistence;
using NeohConcessionaria.Infrastructure.Repositories;
using System.Linq.Expressions;

namespace NeohConcessionaria.Infra.Repositories.Vendas
{
    public class ClienteRespository : Repository<Cliente>, IClienteRepository
    {
        private readonly AppDbContext _context;
        public ClienteRespository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Cliente> Get(Expression<Func<Cliente, bool>> predicate)
        {
            return await _context.Set<Cliente>().Where(e => e.IsDeleted == false).SingleOrDefaultAsync(predicate);
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _context.Set<Cliente>().Where(e => e.IsDeleted == false).ToListAsync();
        }
    }
}
