﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NeohConcessionaria.Infra.Persistence;

#nullable disable

namespace NeohConcessionaria.Infra.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250226001202_migrationFinal")]
    partial class migrationFinal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NeohConcessionaria.Core.Entities.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("NeohConcessionaria.Core.Entities.Concessionaria", b =>
                {
                    b.Property<int>("ConcessionariaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConcessionariaId"));

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CapacidadeMaximaVeiculos")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConcessionariaId");

                    b.ToTable("Concessionarias");
                });

            modelBuilder.Entity("NeohConcessionaria.Core.Entities.Fabricante", b =>
                {
                    b.Property<int>("FabricanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FabricanteId"));

                    b.Property<int>("AnoFundacao")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaisOrigem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("FabricanteId");

                    b.ToTable("Fabricantes");
                });

            modelBuilder.Entity("NeohConcessionaria.Core.Entities.Veiculo", b =>
                {
                    b.Property<int>("VeiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VeiculoId"));

                    b.Property<int>("AnoFabricacao")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FabricanteId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("TipoVeiculo")
                        .HasColumnType("int");

                    b.HasKey("VeiculoId");

                    b.HasIndex("FabricanteId");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("NeohConcessionaria.Core.Entities.Venda", b =>
                {
                    b.Property<int>("VendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VendaId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("ConcessionariaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataVenda")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("PrecoVenda")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("ProtocoloVenda")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("int");

                    b.HasKey("VendaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ConcessionariaId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("NeohConcessionaria.Core.Entities.Veiculo", b =>
                {
                    b.HasOne("NeohConcessionaria.Core.Entities.Fabricante", "Fabricante")
                        .WithMany("Veiculos")
                        .HasForeignKey("FabricanteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Fabricante");
                });

            modelBuilder.Entity("NeohConcessionaria.Core.Entities.Venda", b =>
                {
                    b.HasOne("NeohConcessionaria.Core.Entities.Cliente", "Cliente")
                        .WithMany("Vendas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("NeohConcessionaria.Core.Entities.Concessionaria", "Concessionaria")
                        .WithMany("Vendas")
                        .HasForeignKey("ConcessionariaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("NeohConcessionaria.Core.Entities.Veiculo", "Veiculo")
                        .WithMany("Vendas")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Concessionaria");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("NeohConcessionaria.Core.Entities.Cliente", b =>
                {
                    b.Navigation("Vendas");
                });

            modelBuilder.Entity("NeohConcessionaria.Core.Entities.Concessionaria", b =>
                {
                    b.Navigation("Vendas");
                });

            modelBuilder.Entity("NeohConcessionaria.Core.Entities.Fabricante", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("NeohConcessionaria.Core.Entities.Veiculo", b =>
                {
                    b.Navigation("Vendas");
                });
#pragma warning restore 612, 618
        }
    }
}
