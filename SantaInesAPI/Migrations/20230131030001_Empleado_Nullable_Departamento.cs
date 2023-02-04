using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SantaInesAPI.Migrations
{
    public partial class Empleado_Nullable_Departamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Departamentos_id_departamento",
                table: "Empleados");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_departamento",
                table: "Empleados",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Departamentos_id_departamento",
                table: "Empleados",
                column: "id_departamento",
                principalTable: "Departamentos",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Departamentos_id_departamento",
                table: "Empleados");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_departamento",
                table: "Empleados",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Departamentos_id_departamento",
                table: "Empleados",
                column: "id_departamento",
                principalTable: "Departamentos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
