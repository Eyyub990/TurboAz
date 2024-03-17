using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurboAzApp.Migrations
{
    /// <inheritdoc />
    public partial class NameAdjust : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcments_Models_ModelId",
                table: "Announcments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Announcments",
                table: "Announcments");

            migrationBuilder.RenameTable(
                name: "Announcments",
                newName: "Announcements");

            migrationBuilder.RenameIndex(
                name: "IX_Announcments_ModelId",
                table: "Announcements",
                newName: "IX_Announcements_ModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Announcements",
                table: "Announcements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Models_ModelId",
                table: "Announcements",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Models_ModelId",
                table: "Announcements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Announcements",
                table: "Announcements");

            migrationBuilder.RenameTable(
                name: "Announcements",
                newName: "Announcments");

            migrationBuilder.RenameIndex(
                name: "IX_Announcements_ModelId",
                table: "Announcments",
                newName: "IX_Announcments_ModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Announcments",
                table: "Announcments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcments_Models_ModelId",
                table: "Announcments",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id");
        }
    }
}
