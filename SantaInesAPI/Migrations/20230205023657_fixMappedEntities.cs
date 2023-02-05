using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SantaInesAPI.Migrations
{
    public partial class fixMappedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Empleados_doctor",
                table: "Citas");

            migrationBuilder.AlterColumn<string>(
                name: "doctor",
                table: "Citas",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Empleados_doctor",
                table: "Citas",
                column: "doctor",
                principalTable: "Empleados",
                principalColumn: "username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Empleados_doctor",
                table: "Citas");

            migrationBuilder.AlterColumn<string>(
                name: "doctor",
                table: "Citas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Empleados_doctor",
                table: "Citas",
                column: "doctor",
                principalTable: "Empleados",
                principalColumn: "username",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
