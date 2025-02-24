using NeohConcessionaria.Core.Entities;
using NeohConcessionaria.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeohConcessionaria.Infrastructure.Repositories.Fabricantes
{
    public class FabricanteRepository : Repository<Fabricante>, IFabricanteRepository
    {
        public FabricanteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
