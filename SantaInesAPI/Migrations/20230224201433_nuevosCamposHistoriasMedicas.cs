using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SantaInesAPI.Migrations
{
    public partial class nuevosCamposHistoriasMedicas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "diagnostico",
                table: "HistoriaMedicas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "referencias",
                table: "HistoriaMedicas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "diagnostico",
                table: "HistoriaMedicas");

            migrationBuilder.DropColumn(
                name: "referencias",
                table: "HistoriaMedicas");
        }
    }
}
