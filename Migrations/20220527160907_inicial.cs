using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    FilmeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sinopse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.FilmeId);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaNum = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.SalaId);
                });

            migrationBuilder.CreateTable(
                name: "Sessao",
                columns: table => new
                {
                    SessaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessaoNum = table.Column<int>(type: "int", nullable: false),
                    SalaID = table.Column<int>(type: "int", nullable: false),
                    FilmeID = table.Column<int>(type: "int", nullable: false),
                    IsDublado = table.Column<bool>(type: "bit", nullable: false),
                    IsLegendado = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessao", x => x.SessaoId);
                    table.ForeignKey(
                        name: "FK_Sessao_Filme_FilmeID",
                        column: x => x.FilmeID,
                        principalTable: "Filme",
                        principalColumn: "FilmeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessao_Sala_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Sala",
                        principalColumn: "SalaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingresso",
                columns: table => new
                {
                    IngressoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngressoInteiro = table.Column<bool>(type: "bit", nullable: false),
                    IngressoMeia = table.Column<bool>(type: "bit", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SessaoId = table.Column<int>(type: "int", nullable: false),
                    Fileira = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    AssentoNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresso", x => x.IngressoId);
                    table.ForeignKey(
                        name: "FK_Ingresso_Sessao_SessaoId",
                        column: x => x.SessaoId,
                        principalTable: "Sessao",
                        principalColumn: "SessaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingresso_SessaoId",
                table: "Ingresso",
                column: "SessaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_FilmeID",
                table: "Sessao",
                column: "FilmeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_SalaID",
                table: "Sessao",
                column: "SalaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingresso");

            migrationBuilder.DropTable(
                name: "Sessao");

            migrationBuilder.DropTable(
                name: "Filme");

            migrationBuilder.DropTable(
                name: "Sala");
        }
    }
}
