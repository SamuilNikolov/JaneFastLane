using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JaneFastLane.Data.Migrations
{
    public partial class tablecharacteristicsmodelrelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_Characteristics_CharacteristicsId",
                table: "Table");

            migrationBuilder.AlterColumn<int>(
                name: "CharacteristicsId",
                table: "Table",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Characteristics_CharacteristicsId",
                table: "Table",
                column: "CharacteristicsId",
                principalTable: "Characteristics",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_Characteristics_CharacteristicsId",
                table: "Table");

            migrationBuilder.AlterColumn<int>(
                name: "CharacteristicsId",
                table: "Table",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Characteristics_CharacteristicsId",
                table: "Table",
                column: "CharacteristicsId",
                principalTable: "Characteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
