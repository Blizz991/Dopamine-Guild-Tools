using Microsoft.EntityFrameworkCore.Migrations;

namespace WoW_Guild_Tools.Migrations
{
    public partial class WowData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Raiders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Race = table.Column<string>(type: "nchar(8)", nullable: false),
                    Class = table.Column<string>(type: "nchar(8)", nullable: false),
                    Spec = table.Column<string>(type: "nchar(13)", nullable: false),
                    Role = table.Column<string>(type: "nchar(6)", nullable: false),
                    Rank = table.Column<string>(type: "nchar(11)", nullable: false),
                    Profession1 = table.Column<string>(type: "nchar(15)", nullable: false),
                    Profession2 = table.Column<string>(type: "nchar(15)", nullable: false),
                    MainId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raiders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Raiders_Raiders_MainId",
                        column: x => x.MainId,
                        principalTable: "Raiders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Raiders_MainId",
                table: "Raiders",
                column: "MainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Raiders");
        }
    }
}
