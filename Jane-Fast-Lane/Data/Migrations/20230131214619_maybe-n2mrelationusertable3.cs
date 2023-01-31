using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jane_Fast_Lane.Data.Migrations
{
    public partial class mayben2mrelationusertable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_AspNetUsers_ApplicationUserId",
                table: "Table");

            migrationBuilder.DropIndex(
                name: "IX_Table_ApplicationUserId",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "WaiterId",
                table: "Table");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Table",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WaiterId",
                table: "Table",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Table_ApplicationUserId",
                table: "Table",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_AspNetUsers_ApplicationUserId",
                table: "Table",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
