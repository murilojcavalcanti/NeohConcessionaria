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

namespace NeohConcessionaria.Infra.Repositories.Concessionarias
{
    public class ConcessionariaRepository : Repository<Concessionaria>, IConcessionariaRepository
    {
        private readonly AppDbContext _context;
        public ConcessionariaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Concessionaria> Get(Expression<Func<Concessionaria, bool>> predicate)
        {
            return await _context.Set<Concessionaria>().Where(e => e.IsDeleted == false).SingleOrDefaultAsync(predicate);
        }

        public async Task<List<Concessionaria>> GetAll()
        {
            return await _context.Set<Concessionaria>().Where(e => e.IsDeleted == false).ToListAsync();
        }

    }
}
