using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pruebaEdwin.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentToUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Document",
                table: "Usuarios",
                column: "Document",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Document",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "Usuarios");
        }
    }
}
