using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jane_Fast_Lane.Data.Migrations
{
    public partial class mayben2mrelationusertable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_AspNetUsers_ApplicationUserId1",
                table: "Table");

            migrationBuilder.DropIndex(
                name: "IX_Table_ApplicationUserId1",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Table");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Table",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_AspNetUsers_ApplicationUserId",
                table: "Table");

            migrationBuilder.DropIndex(
                name: "IX_Table_ApplicationUserId",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "WaiterId",
                table: "Table");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Table",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
    }
}
