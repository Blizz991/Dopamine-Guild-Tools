using Microsoft.EntityFrameworkCore.Migrations;

namespace WoW_Guild_Tools.Migrations
{
    public partial class AddProfessions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionName = table.Column<string>(type: "nchar(15)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    WowRecipeId = table.Column<int>(type: "int", nullable: false),
                    WowCraftedItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Professions_ProfessionName",
                        column: x => x.ProfessionName,
                        principalTable: "Professions",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaiderRecipe",
                columns: table => new
                {
                    CrafterRaidersId = table.Column<int>(type: "int", nullable: false),
                    RecipesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaiderRecipe", x => new { x.CrafterRaidersId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_RaiderRecipe_Raiders_CrafterRaidersId",
                        column: x => x.CrafterRaidersId,
                        principalTable: "Raiders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaiderRecipe_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaiderRecipe_RecipesId",
                table: "RaiderRecipe",
                column: "RecipesId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ProfessionName",
                table: "Recipes",
                column: "ProfessionName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaiderRecipe");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Professions");
        }
    }
}
