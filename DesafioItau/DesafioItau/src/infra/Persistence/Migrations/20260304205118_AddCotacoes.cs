using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioItau.src.infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCotacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cotacoes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataPregao = table.Column<DateOnly>(type: "date", nullable: false),
                    Ticker = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrecoAbertura = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PrecoFechamento = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PrecoMaximo = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PrecoMinimo = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotacoes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Cotacoes_DataPregao_Ticker",
                table: "Cotacoes",
                columns: new[] { "DataPregao", "Ticker" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cotacoes");
        }
    }
}
