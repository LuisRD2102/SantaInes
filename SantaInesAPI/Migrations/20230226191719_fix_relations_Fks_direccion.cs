using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SantaInesAPI.Migrations
{
    public partial class fix_relations_Fks_direccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Direccion_id_estado",
                table: "Direccion");

            migrationBuilder.DropIndex(
                name: "IX_Direccion_id_municipio",
                table: "Direccion");

            migrationBuilder.DropIndex(
                name: "IX_Direccion_id_parroquia",
                table: "Direccion");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_id_estado",
                table: "Direccion",
                column: "id_estado");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_id_municipio",
                table: "Direccion",
                column: "id_municipio");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_id_parroquia",
                table: "Direccion",
                column: "id_parroquia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Direccion_id_estado",
                table: "Direccion");

            migrationBuilder.DropIndex(
                name: "IX_Direccion_id_municipio",
                table: "Direccion");

            migrationBuilder.DropIndex(
                name: "IX_Direccion_id_parroquia",
                table: "Direccion");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_id_estado",
                table: "Direccion",
                column: "id_estado",
                unique: true,
                filter: "[id_estado] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_id_municipio",
                table: "Direccion",
                column: "id_municipio",
                unique: true,
                filter: "[id_municipio] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_id_parroquia",
                table: "Direccion",
                column: "id_parroquia",
                unique: true,
                filter: "[id_parroquia] IS NOT NULL");
        }
    }
}
