using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jane_Fast_Lane.Data.Migrations
{
    public partial class mayben2mrelationusertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Table",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Table",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Table_ApplicationUserId1",
                table: "Table",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_AspNetUsers_ApplicationUserId1",
                table: "Table",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_AspNetUsers_ApplicationUserId1",
                table: "Table");

            migrationBuilder.DropIndex(
                name: "IX_Table_ApplicationUserId1",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Table");
        }
    }
}
