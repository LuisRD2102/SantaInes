using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SantaInesAPI.Migrations
{
    public partial class NoDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Empleados_doctor",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuario_paciente",
                table: "Citas");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Empleados_doctor",
                table: "Citas",
                column: "doctor",
                principalTable: "Empleados",
                principalColumn: "username",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Usuario_paciente",
                table: "Citas",
                column: "paciente",
                principalTable: "Usuario",
                principalColumn: "username",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Empleados_doctor",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuario_paciente",
                table: "Citas");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Empleados_doctor",
                table: "Citas",
                column: "doctor",
                principalTable: "Empleados",
                principalColumn: "username",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Usuario_paciente",
                table: "Citas",
                column: "paciente",
                principalTable: "Usuario",
                principalColumn: "username",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
