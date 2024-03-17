using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurboAzApp.Migrations
{
    /// <inheritdoc />
    public partial class Columnadjust : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "decimal",
                table: "Announcements",
                newName: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Announcements",
                newName: "decimal");
        }
    }
}
