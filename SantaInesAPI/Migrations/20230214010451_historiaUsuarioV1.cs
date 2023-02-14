using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SantaInesAPI.Migrations
{
    public partial class historiaUsuarioV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "idHistoria",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "HistoriaMedicas",
                columns: table => new
                {
                    idHistoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    peso = table.Column<float>(type: "real", nullable: true),
                    altura = table.Column<float>(type: "real", nullable: true),
                    tipoSangre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    antPeronales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    andtFamiliares = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alergias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tratHabitual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    intQuirurgica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patologia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriaMedicas", x => x.idHistoria);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idHistoria",
                table: "Usuario",
                column: "idHistoria",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_HistoriaMedicas_idHistoria",
                table: "Usuario",
                column: "idHistoria",
                principalTable: "HistoriaMedicas",
                principalColumn: "idHistoria",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_HistoriaMedicas_idHistoria",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "HistoriaMedicas");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_idHistoria",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "idHistoria",
                table: "Usuario");
        }
    }
}
