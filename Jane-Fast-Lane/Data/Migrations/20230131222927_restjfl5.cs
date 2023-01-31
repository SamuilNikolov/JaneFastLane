using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jane_Fast_Lane.Data.Migrations
{
    public partial class restjfl5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Table",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WaiterId",
                table: "Table",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Table_ApplicationUserId",
                table: "Table",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Table_WaiterId",
                table: "Table",
                column: "WaiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_AspNetUsers_ApplicationUserId",
                table: "Table",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_AspNetUsers_WaiterId",
                table: "Table",
                column: "WaiterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_AspNetUsers_ApplicationUserId",
                table: "Table");

            migrationBuilder.DropForeignKey(
                name: "FK_Table_AspNetUsers_WaiterId",
                table: "Table");

            migrationBuilder.DropIndex(
                name: "IX_Table_ApplicationUserId",
                table: "Table");

            migrationBuilder.DropIndex(
                name: "IX_Table_WaiterId",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "WaiterId",
                table: "Table");
        }
    }
}
