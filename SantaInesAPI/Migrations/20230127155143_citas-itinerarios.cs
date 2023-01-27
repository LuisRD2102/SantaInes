using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SantaInesAPI.Migrations
{
    public partial class citasitinerarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "id_itinerario",
                table: "Empleados",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    paciente = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    doctor = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id_departamento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Departamentoid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Citas_Departamentos_Departamentoid",
                        column: x => x.Departamentoid,
                        principalTable: "Departamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Empleados_doctor",
                        column: x => x.doctor,
                        principalTable: "Empleados",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citas_Usuario_paciente",
                        column: x => x.paciente,
                        principalTable: "Usuario",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Itinerarios",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    hora_inicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hora_fin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itinerarios", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_id_itinerario",
                table: "Empleados",
                column: "id_itinerario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Departamentoid",
                table: "Citas",
                column: "Departamentoid");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_doctor",
                table: "Citas",
                column: "doctor");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_paciente",
                table: "Citas",
                column: "paciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Itinerarios_id_itinerario",
                table: "Empleados",
                column: "id_itinerario",
                principalTable: "Itinerarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Itinerarios_id_itinerario",
                table: "Empleados");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Itinerarios");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_id_itinerario",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "id_itinerario",
                table: "Empleados");
        }
    }
}
