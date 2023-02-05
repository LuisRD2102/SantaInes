using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SantaInesAPI.Migrations
{
    public partial class RefactorVariablesNoUsadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuario_paciente",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Itinerarios_id_itinerario",
                table: "Empleados");

            migrationBuilder.DropTable(
                name: "Itinerarios");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_id_itinerario",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "id_itinerario",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "nombre_paciente",
                table: "Citas");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Usuario_paciente",
                table: "Citas",
                column: "paciente",
                principalTable: "Usuario",
                principalColumn: "username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuario_paciente",
                table: "Citas");

            migrationBuilder.AddColumn<Guid>(
                name: "id_itinerario",
                table: "Empleados",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nombre_paciente",
                table: "Citas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Itinerarios",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    hora_fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hora_inicio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itinerarios", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_id_itinerario",
                table: "Empleados",
                column: "id_itinerario",
                unique: true,
                filter: "[id_itinerario] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Usuario_paciente",
                table: "Citas",
                column: "paciente",
                principalTable: "Usuario",
                principalColumn: "username",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Itinerarios_id_itinerario",
                table: "Empleados",
                column: "id_itinerario",
                principalTable: "Itinerarios",
                principalColumn: "id");
        }
    }
}
