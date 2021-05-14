using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WoW_Guild_Tools.Migrations
{
    public partial class RaidGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RaidGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    RaidDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaidGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupRaiders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupNumber = table.Column<int>(type: "int", nullable: false),
                    GroupPosition = table.Column<int>(type: "int", nullable: false),
                    RaidGroupId = table.Column<int>(type: "int", nullable: false),
                    RaiderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupRaiders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupRaiders_Raiders_RaiderId",
                        column: x => x.RaiderId,
                        principalTable: "Raiders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupRaiders_RaidGroups_RaidGroupId",
                        column: x => x.RaidGroupId,
                        principalTable: "RaidGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupRaiders_RaiderId",
                table: "GroupRaiders",
                column: "RaiderId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRaiders_RaidGroupId",
                table: "GroupRaiders",
                column: "RaidGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupRaiders");

            migrationBuilder.DropTable(
                name: "RaidGroups");
        }
    }
}
