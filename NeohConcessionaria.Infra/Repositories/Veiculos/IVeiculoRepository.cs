using NeohConcessionaria.Core.Entities;
using System.Linq.Expressions;

namespace NeohConcessionaria.Infra.Repositories.Veiculos
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        Task<List<Veiculo>> GetAll(); 
        Task<Veiculo> Get(Expression<Func<Veiculo, bool>> predicate);
        Task<List<Veiculo>> GetPorFabricante(int FabricanteId);
    }
}
