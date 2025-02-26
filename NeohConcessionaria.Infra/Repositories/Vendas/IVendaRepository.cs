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
    public interface IVendaRepository:IRepository<Venda>
    {
        Task<List<Venda>> GetAll();
        Task<Venda> Get(Expression<Func<Venda,bool>>predicate);
        
    }
}
