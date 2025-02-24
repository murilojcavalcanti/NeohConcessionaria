using Microsoft.EntityFrameworkCore;
using NeohConcessionaria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeohConcessionaria.Infra.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        public DbSet<Fabricante> Fabricantes { get; set; }
    }
}
