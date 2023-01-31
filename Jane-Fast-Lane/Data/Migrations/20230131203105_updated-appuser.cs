using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jane_Fast_Lane.Data.Migrations
{
    public partial class updatedappuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_AspNetUsers_ApplicationUserId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Table_AspNetUsers_ApplicationUserId",
                table: "Table");

            migrationBuilder.DropIndex(
                name: "IX_Table_ApplicationUserId",
                table: "Table");

            migrationBuilder.DropIndex(
                name: "IX_Menu_ApplicationUserId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Menu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Table",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Menu",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Table_ApplicationUserId",
                table: "Table",
                column: "ApplicationUserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Table_AspNetUsers_ApplicationUserId",
                table: "Table",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
