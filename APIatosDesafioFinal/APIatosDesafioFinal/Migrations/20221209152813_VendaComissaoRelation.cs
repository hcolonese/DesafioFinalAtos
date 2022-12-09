using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIatosDesafioFinal.Migrations
{
    /// <inheritdoc />
    public partial class VendaComissaoRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comissao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Relatorio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotaFiscal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    DataRebimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VendaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comissao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comissao_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comissao_VendaId",
                table: "Comissao",
                column: "VendaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comissao");
        }
    }
}
