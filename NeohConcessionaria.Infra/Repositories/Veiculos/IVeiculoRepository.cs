using NeohConcessionaria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeohConcessionaria.Infra.Repositories.Veiculos
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        List<Veiculo> GetAllDetails();
    }
}
