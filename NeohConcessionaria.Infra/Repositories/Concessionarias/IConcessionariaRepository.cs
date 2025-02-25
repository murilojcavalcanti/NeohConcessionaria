using NeohConcessionaria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NeohConcessionaria.Infra.Repositories.Concessionarias
{
    public interface IConcessionariaRepository:IRepository<Concessionaria>
    {
        Task<Concessionaria> Get(Expression<Func<Concessionaria, bool>> predicate);
        Task<List<Concessionaria>> GetAll();
    }
}
