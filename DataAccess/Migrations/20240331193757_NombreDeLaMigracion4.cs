using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeLaMigracion4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nacionalidad",
                table: "Autores");

            migrationBuilder.AddColumn<int>(
                name: "NacionalidadId",
                table: "Autores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Autores_NacionalidadId",
                table: "Autores",
                column: "NacionalidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autores_Nacionalidades_NacionalidadId",
                table: "Autores",
                column: "NacionalidadId",
                principalTable: "Nacionalidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autores_Nacionalidades_NacionalidadId",
                table: "Autores");

            migrationBuilder.DropIndex(
                name: "IX_Autores_NacionalidadId",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "NacionalidadId",
                table: "Autores");

            migrationBuilder.AddColumn<string>(
                name: "Nacionalidad",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
