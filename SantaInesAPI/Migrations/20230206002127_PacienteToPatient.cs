using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SantaInesAPI.Migrations
{
    public partial class PacienteToPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuario_paciente",
                table: "Citas");

            migrationBuilder.RenameColumn(
                name: "paciente",
                table: "Citas",
                newName: "patient");

            migrationBuilder.RenameIndex(
                name: "IX_Citas_paciente",
                table: "Citas",
                newName: "IX_Citas_patient");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Usuario_patient",
                table: "Citas",
                column: "patient",
                principalTable: "Usuario",
                principalColumn: "username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuario_patient",
                table: "Citas");

            migrationBuilder.RenameColumn(
                name: "patient",
                table: "Citas",
                newName: "paciente");

            migrationBuilder.RenameIndex(
                name: "IX_Citas_patient",
                table: "Citas",
                newName: "IX_Citas_paciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Usuario_paciente",
                table: "Citas",
                column: "paciente",
                principalTable: "Usuario",
                principalColumn: "username");
        }
    }
}
