using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JaneFastLane.Data.Migrations
{
    public partial class appuseraddedcart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Menu",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ApplicationUserId",
                table: "Menu",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_AspNetUsers_ApplicationUserId",
                table: "Menu",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_AspNetUsers_ApplicationUserId",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_ApplicationUserId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Menu");
        }
    }
}
