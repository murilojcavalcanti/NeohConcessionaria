using Microsoft.EntityFrameworkCore;
using NeohConcessionaria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NeohConcessionaria.Infra.Repositories.Vendas
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<List<Cliente>> GetAll();
        Task<Cliente> Get(Expression<Func<Cliente, bool>>predicate);
        
    }
}
