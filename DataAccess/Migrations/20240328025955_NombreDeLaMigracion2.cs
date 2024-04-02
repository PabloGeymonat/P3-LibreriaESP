using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeLaMigracion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaisOrigen",
                table: "Editoriales");

            migrationBuilder.AddColumn<int>(
                name: "PaisOrigenId",
                table: "Editoriales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Editoriales_PaisOrigenId",
                table: "Editoriales",
                column: "PaisOrigenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Editoriales_Paises_PaisOrigenId",
                table: "Editoriales",
                column: "PaisOrigenId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Editoriales_Paises_PaisOrigenId",
                table: "Editoriales");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropIndex(
                name: "IX_Editoriales_PaisOrigenId",
                table: "Editoriales");

            migrationBuilder.DropColumn(
                name: "PaisOrigenId",
                table: "Editoriales");

            migrationBuilder.AddColumn<string>(
                name: "PaisOrigen",
                table: "Editoriales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
