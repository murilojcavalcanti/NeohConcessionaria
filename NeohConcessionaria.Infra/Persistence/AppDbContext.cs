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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Veiculo>(e =>
            {
                e.HasKey(v => v.VeiculoId);

                e.HasOne(v => v.Fabricante)
                .WithMany(f => f.Veiculos)
                .HasForeignKey(v => v.FabricanteId)
                .OnDelete(DeleteBehavior.Restrict);
            });
                builder.Entity<Venda>(e =>
                {
                    e.HasKey(v => v.VendaId);

                    e.HasOne(v => v.Veiculo)
                    .WithMany(VE => VE.Vendas)
                    .HasForeignKey(v => v.VeiculoId)
                    .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(v => v.Cliente)
                    .WithMany(c => c.Vendas)
                    .HasForeignKey(v => v.ClienteId)
                    .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(v => v.Concessionaria)
                    .WithMany(c => c.Vendas)
                    .HasForeignKey(v => v.ConcessionariaId)
                    .OnDelete(DeleteBehavior.Restrict);
                });
        }

        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Concessionaria> Concessionarias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venda> Vendas { get; set; }

    }
}
