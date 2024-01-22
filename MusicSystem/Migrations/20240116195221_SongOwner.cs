using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicSystem.Migrations
{
    /// <inheritdoc />
    public partial class SongOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_OwnerId",
                table: "Songs",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Users_OwnerId",
                table: "Songs",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Users_OwnerId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_OwnerId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Songs");
        }
    }
}
