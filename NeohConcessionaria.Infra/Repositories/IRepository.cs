using NeohConcessionaria.Core.Entities;
using System.Linq.Expressions;
namespace NeohConcessionaria.Infra.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Create(T Entity);
        
        void Update(T Entity);
        void Delete(T Entity);
    }
}
