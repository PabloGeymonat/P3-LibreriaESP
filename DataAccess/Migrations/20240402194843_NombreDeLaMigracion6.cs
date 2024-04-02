using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeLaMigracion6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "Editoriales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Editoriales_PaisId",
                table: "Editoriales",
                column: "PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Editoriales_Paises_PaisId",
                table: "Editoriales",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Editoriales_Paises_PaisId",
                table: "Editoriales");

            migrationBuilder.DropIndex(
                name: "IX_Editoriales_PaisId",
                table: "Editoriales");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "Editoriales");
        }
    }
}
