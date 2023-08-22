using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WindemereManorWeb.Migrations
{
    /// <inheritdoc />
    public partial class PropAdd_Location : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FridgeItem",
                table: "FridgeItem");

            migrationBuilder.RenameTable(
                name: "FridgeItem",
                newName: "FridgeItems");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "FridgeItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FridgeItems",
                table: "FridgeItems",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FridgeItems",
                table: "FridgeItems");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "FridgeItems");

            migrationBuilder.RenameTable(
                name: "FridgeItems",
                newName: "FridgeItem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FridgeItem",
                table: "FridgeItem",
                column: "ID");
        }
    }
}
