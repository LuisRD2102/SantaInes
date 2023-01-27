using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SantaInesAPI.Migrations
{
    public partial class NullableItinerarioNormalEmpleados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Itinerarios_id_itinerario",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_id_itinerario",
                table: "Empleados");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_itinerario",
                table: "Empleados",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_id_itinerario",
                table: "Empleados",
                column: "id_itinerario",
                unique: true,
                filter: "[id_itinerario] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Itinerarios_id_itinerario",
                table: "Empleados",
                column: "id_itinerario",
                principalTable: "Itinerarios",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Itinerarios_id_itinerario",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_id_itinerario",
                table: "Empleados");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_itinerario",
                table: "Empleados",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_id_itinerario",
                table: "Empleados",
                column: "id_itinerario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Itinerarios_id_itinerario",
                table: "Empleados",
                column: "id_itinerario",
                principalTable: "Itinerarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
