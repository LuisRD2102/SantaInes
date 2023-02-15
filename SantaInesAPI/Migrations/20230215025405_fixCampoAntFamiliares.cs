using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SantaInesAPI.Migrations
{
    public partial class fixCampoAntFamiliares : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "andtFamiliares",
                table: "HistoriaMedicas",
                newName: "antFamiliares");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "antFamiliares",
                table: "HistoriaMedicas",
                newName: "andtFamiliares");
        }
    }
}
