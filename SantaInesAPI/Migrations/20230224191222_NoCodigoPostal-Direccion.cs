using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SantaInesAPI.Migrations
{
    public partial class NoCodigoPostalDireccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cod_postal",
                table: "Direccion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cod_postal",
                table: "Direccion",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
