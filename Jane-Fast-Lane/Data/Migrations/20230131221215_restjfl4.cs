using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jane_Fast_Lane.Data.Migrations
{
    public partial class restjfl4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_AspNetUsers_WaiterId",
                table: "Table");

            migrationBuilder.RenameColumn(
                name: "WaiterId",
                table: "Table",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Table_WaiterId",
                table: "Table",
                newName: "IX_Table_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_AspNetUsers_CustomerId",
                table: "Table",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_AspNetUsers_CustomerId",
                table: "Table");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Table",
                newName: "WaiterId");

            migrationBuilder.RenameIndex(
                name: "IX_Table_CustomerId",
                table: "Table",
                newName: "IX_Table_WaiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_AspNetUsers_WaiterId",
                table: "Table",
                column: "WaiterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
