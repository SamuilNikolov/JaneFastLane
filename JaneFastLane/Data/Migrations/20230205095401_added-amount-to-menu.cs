using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JaneFastLane.Data.Migrations
{
    public partial class addedamounttomenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Menu",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Menu");
        }
    }
}
