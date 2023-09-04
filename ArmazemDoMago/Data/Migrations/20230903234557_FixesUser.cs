using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmazemDoMago.Migrations
{
    /// <inheritdoc />
    public partial class FixesUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Usuarios",
                newName: "SenhaHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenhaHash",
                table: "Usuarios",
                newName: "Nome");
        }
    }
}
