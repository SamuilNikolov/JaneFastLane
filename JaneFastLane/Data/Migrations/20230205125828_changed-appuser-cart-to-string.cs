using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JaneFastLane.Data.Migrations
{
    public partial class changedappusercarttostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_AspNetUsers_ApplicationUserId",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_ApplicationUserId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Menu");

            migrationBuilder.AddColumn<string>(
                name: "Cart",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cart",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Menu",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
