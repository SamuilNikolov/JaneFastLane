using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jane_Fast_Lane.Data.Migrations
{
    public partial class Changedappuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Client",
                table: "Order",
                newName: "WaiterId");

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RatingFood",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RatingWaiter",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Menu",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_TableId",
                table: "Order",
                column: "TableId");

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
                name: "FK_Order_Table_TableId",
                table: "Order",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_AspNetUsers_ApplicationUserId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Table_TableId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_TableId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Menu_ApplicationUserId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CompletionDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "RatingFood",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "RatingWaiter",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Menu");

            migrationBuilder.RenameColumn(
                name: "WaiterId",
                table: "Order",
                newName: "Client");
        }
    }
}
