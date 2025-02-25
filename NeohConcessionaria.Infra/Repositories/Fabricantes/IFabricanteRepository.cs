using NeohConcessionaria.Core.Entities;
using NeohConcessionaria.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NeohConcessionaria.Infrastructure.Repositories.Fabricantes
{
    public interface IFabricanteRepository:IRepository<Fabricante>
    {
        Task<Fabricante> Get(Expression<Func<Fabricante, bool>> predicate);
        Task<List<Fabricante>> GetAll();
    }
}
