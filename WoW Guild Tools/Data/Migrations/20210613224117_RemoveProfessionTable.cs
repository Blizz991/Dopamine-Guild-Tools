using Microsoft.EntityFrameworkCore.Migrations;

namespace WoW_Guild_Tools.Migrations
{
    public partial class RemoveProfessionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Professions_ProfessionName",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_ProfessionName",
                table: "Recipes");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessionName",
                table: "Recipes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(15)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfessionName",
                table: "Recipes",
                type: "nchar(15)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ProfessionName",
                table: "Recipes",
                column: "ProfessionName");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Professions_ProfessionName",
                table: "Recipes",
                column: "ProfessionName",
                principalTable: "Professions",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
