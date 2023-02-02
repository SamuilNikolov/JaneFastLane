using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JaneFastLane.Data.Migrations
{
    public partial class changedto1tablemanyusersrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_AspNetUsers_CustomerId",
                table: "Table");

            migrationBuilder.DropIndex(
                name: "IX_Table_CustomerId",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Table");

            migrationBuilder.AddColumn<int>(
                name: "TableCustomerId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TableCustomerId",
                table: "AspNetUsers",
                column: "TableCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TableId",
                table: "AspNetUsers",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Table_TableCustomerId",
                table: "AspNetUsers",
                column: "TableCustomerId",
                principalTable: "Table",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Table_TableId",
                table: "AspNetUsers",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Table_TableCustomerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Table_TableId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TableCustomerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TableId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TableCustomerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Table",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Table_CustomerId",
                table: "Table",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_AspNetUsers_CustomerId",
                table: "Table",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
