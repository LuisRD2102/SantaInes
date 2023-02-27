using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SantaInesAPI.Migrations
{
    public partial class presidenteUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "username", "apellido_completo", "cedula", "id_departamento", "nombre_completo", "password", "rol", "sexo" },
                values: new object[] { "00000001", "Principal", 1, null, "Administrador", "12345678", "Presidencia", "M" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "username",
                keyValue: "00000001");
        }
    }
}
