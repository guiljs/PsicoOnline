using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Psico.Data.Migrations
{
    public partial class Cria_Profissional_Escala_Consulta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escala",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaDaSemana = table.Column<int>(nullable: false),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Fim = table.Column<DateTime>(nullable: false),
                    DuracaoMinutos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escala", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoProfissional",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProfissional", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profissional",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Conselho = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Biografia = table.Column<string>(nullable: true),
                    TipoProfissionalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profissional_TipoProfissional_TipoProfissionalId",
                        column: x => x.TipoProfissionalId,
                        principalTable: "TipoProfissional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente_IDId = table.Column<string>(nullable: true),
                    Profissional_IDId = table.Column<int>(nullable: true),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Fim = table.Column<DateTime>(nullable: false),
                    Preco = table.Column<double>(nullable: false),
                    Autorizado = table.Column<bool>(nullable: false),
                    Cancelado = table.Column<bool>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consulta_AspNetUsers_Cliente_IDId",
                        column: x => x.Cliente_IDId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consulta_Profissional_Profissional_IDId",
                        column: x => x.Profissional_IDId,
                        principalTable: "Profissional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_Cliente_IDId",
                table: "Consulta",
                column: "Cliente_IDId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_Profissional_IDId",
                table: "Consulta",
                column: "Profissional_IDId");

            migrationBuilder.CreateIndex(
                name: "IX_Profissional_TipoProfissionalId",
                table: "Profissional",
                column: "TipoProfissionalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Escala");

            migrationBuilder.DropTable(
                name: "Profissional");

            migrationBuilder.DropTable(
                name: "TipoProfissional");
        }
    }
}
