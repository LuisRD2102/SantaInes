using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SantaInesAPI.Migrations
{
    public partial class fixFKDepartamento_Citas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Departamentos_Departamentoid",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_Departamentoid",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "Departamentoid",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "id_departamento",
                table: "Citas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Departamentoid",
                table: "Citas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "id_departamento",
                table: "Citas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Departamentoid",
                table: "Citas",
                column: "Departamentoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Departamentos_Departamentoid",
                table: "Citas",
                column: "Departamentoid",
                principalTable: "Departamentos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
