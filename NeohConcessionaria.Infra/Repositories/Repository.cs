using Microsoft.EntityFrameworkCore;
using NeohConcessionaria.Core.Entities;
using NeohConcessionaria.Infra.Persistence;
using NeohConcessionaria.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NeohConcessionaria.Infrastructure.Repositories
{
    public class Repository<T>: IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T Entity)
        {
           var created = await _context.Set<T>().AddAsync(Entity);
            _context.SaveChanges();
            return Entity;
        }

        public void Delete(T Entity)
        {
            Entity.IsDeleted = true;
            _context.Set<T>().Update(Entity);
            _context.SaveChanges();
        }

        public void Update(T Entity)
        {

            _context.Set<T>().Update(Entity);
            _context.SaveChanges();
        }
    }
}
