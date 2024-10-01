using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M7Tarea1.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Api10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormaPago",
                table: "Ventas",
                type: "nvarchar(150)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormaPago",
                table: "Ventas");
        }
    }
}
