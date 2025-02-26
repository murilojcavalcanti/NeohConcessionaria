using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NeohConcessionaria.Core.Entities;

#nullable disable

namespace NeohConcessionaria.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migrationFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.UniqueConstraint("AK_Clientes_CPF", x => x.CPF);
                });
                

            migrationBuilder.CreateTable(
                name: "Concessionarias",
                columns: table => new
                {
                    ConcessionariaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CapacidadeMaximaVeiculos = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concessionarias", x => x.ConcessionariaId);
                    table.UniqueConstraint("AK_Concessionarias_Nome", c => c.Nome);

                });

            migrationBuilder.CreateTable(
                name: "Fabricantes",
                columns: table => new
                {
                    FabricanteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PaisOrigem = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    AnoFundacao = table.Column<int>(type: "int", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricantes", x => x.FabricanteId);
                    table.UniqueConstraint("AK_Fabricantes_Nome", f => f.Nome);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    VeiculoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    AnoFabricacao = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FabricanteId = table.Column<int>(type: "int", nullable: false),
                    TipoVeiculo = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.VeiculoId);
                    table.ForeignKey(
                        name: "FK_Veiculos_Fabricantes_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricantes",
                        principalColumn: "FabricanteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    VendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    ConcessionariaId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecoVenda = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ProtocoloVenda = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.VendaId);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_Concessionarias_ConcessionariaId",
                        column: x => x.ConcessionariaId,
                        principalTable: "Concessionarias",
                        principalColumn: "ConcessionariaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "VeiculoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_FabricanteId",
                table: "Veiculos",
                column: "FabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteId",
                table: "Vendas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ConcessionariaId",
                table: "Vendas",
                column: "ConcessionariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VeiculoId",
                table: "Vendas",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Concessionarias");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Fabricantes");
        }
    }
}
