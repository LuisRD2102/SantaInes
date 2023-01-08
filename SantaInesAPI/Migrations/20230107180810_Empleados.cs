using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SantaInesAPI.Migrations
{
    public partial class Empleados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Departamentos_Departamentoid",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_Departamentoid",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Departamentoid",
                table: "Usuario");

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cedula = table.Column<int>(type: "int", nullable: false),
                    nombre_completo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido_completo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_departamento = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.username);
                    table.ForeignKey(
                        name: "FK_Empleados_Departamentos_id_departamento",
                        column: x => x.id_departamento,
                        principalTable: "Departamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_id_departamento",
                table: "Empleados",
                column: "id_departamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.AddColumn<Guid>(
                name: "Departamentoid",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Departamentoid",
                table: "Usuario",
                column: "Departamentoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Departamentos_Departamentoid",
                table: "Usuario",
                column: "Departamentoid",
                principalTable: "Departamentos",
                principalColumn: "id");
        }
    }
}
