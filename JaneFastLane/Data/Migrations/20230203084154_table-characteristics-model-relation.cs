using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JaneFastLane.Data.Migrations
{
    public partial class tablecharacteristicsmodelrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Characteristics",
                table: "Table");

            migrationBuilder.AddColumn<int>(
                name: "CharacteristicsId",
                table: "Table",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Characteristics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Characteristic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characteristics", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Table_CharacteristicsId",
                table: "Table",
                column: "CharacteristicsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Characteristics_CharacteristicsId",
                table: "Table",
                column: "CharacteristicsId",
                principalTable: "Characteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_Characteristics_CharacteristicsId",
                table: "Table");

            migrationBuilder.DropTable(
                name: "Characteristics");

            migrationBuilder.DropIndex(
                name: "IX_Table_CharacteristicsId",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "CharacteristicsId",
                table: "Table");

            migrationBuilder.AddColumn<string>(
                name: "Characteristics",
                table: "Table",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
