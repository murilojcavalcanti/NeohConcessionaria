using Microsoft.EntityFrameworkCore;
using NeohConcessionaria.Core.Entities;
using NeohConcessionaria.Infra.Persistence;
using NeohConcessionaria.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeohConcessionaria.Infra.Repositories.Veiculos
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        private AppDbContext _Context;
        public VeiculoRepository(AppDbContext context) : base(context)
        {
            _Context = context;
        }

        public List<Veiculo> GetAllDetails()
        {
            return _Context.Veiculos.Where(v =>v.IsDeleted==false).Include(v=>v.Fabricante).ToList();
        }
    }
}
