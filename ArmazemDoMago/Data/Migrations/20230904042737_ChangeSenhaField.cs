using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmazemDoMago.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSenhaField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenhaHash",
                table: "Usuarios",
                newName: "Senha");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuarios",
                newName: "SenhaHash");
        }
    }
}
