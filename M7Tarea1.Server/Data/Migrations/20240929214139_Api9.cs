using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M7Tarea1.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Api9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoDocumento",
                table: "Personas",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoDocumento",
                table: "Personas");
        }
    }
}
