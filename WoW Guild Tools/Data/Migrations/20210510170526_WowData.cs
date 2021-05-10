using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WoW_Guild_Tools.Data.Migrations
{
    public partial class WowData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RaiderRank",
                columns: table => new
                {
                    RaiderRankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaiderRankName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaiderRank", x => x.RaiderRankId);
                });

            migrationBuilder.CreateTable(
                name: "WowClasses",
                columns: table => new
                {
                    WowClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WowClasses", x => x.WowClassId);
                });

            migrationBuilder.CreateTable(
                name: "WowFaction",
                columns: table => new
                {
                    WowFactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WowFaction", x => x.WowFactionId);
                });

            migrationBuilder.CreateTable(
                name: "WowRole",
                columns: table => new
                {
                    WowRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WowRole", x => x.WowRoleId);
                });

            migrationBuilder.CreateTable(
                name: "WowSpecs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WowSpecs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    WowRaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WowFactionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.WowRaceId);
                    table.ForeignKey(
                        name: "FK_Races_WowFaction_WowFactionId",
                        column: x => x.WowFactionId,
                        principalTable: "WowFaction",
                        principalColumn: "WowFactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WowClassWowSpec",
                columns: table => new
                {
                    WowClassesWowClassId = table.Column<int>(type: "int", nullable: false),
                    WowSpecsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WowClassWowSpec", x => new { x.WowClassesWowClassId, x.WowSpecsId });
                    table.ForeignKey(
                        name: "FK_WowClassWowSpec_WowClasses_WowClassesWowClassId",
                        column: x => x.WowClassesWowClassId,
                        principalTable: "WowClasses",
                        principalColumn: "WowClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WowClassWowSpec_WowSpecs_WowSpecsId",
                        column: x => x.WowSpecsId,
                        principalTable: "WowSpecs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Raiders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    RaceWowRaceId = table.Column<int>(type: "int", nullable: true),
                    ClassWowClassId = table.Column<int>(type: "int", nullable: true),
                    SpecId = table.Column<int>(type: "int", nullable: true),
                    RoleWowRoleId = table.Column<int>(type: "int", nullable: true),
                    RankRaiderRankId = table.Column<int>(type: "int", nullable: true),
                    IsAlt = table.Column<bool>(type: "bit", nullable: false),
                    MainId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raiders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Raiders_Races_RaceWowRaceId",
                        column: x => x.RaceWowRaceId,
                        principalTable: "Races",
                        principalColumn: "WowRaceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Raiders_RaiderRank_RankRaiderRankId",
                        column: x => x.RankRaiderRankId,
                        principalTable: "RaiderRank",
                        principalColumn: "RaiderRankId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Raiders_Raiders_MainId",
                        column: x => x.MainId,
                        principalTable: "Raiders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Raiders_WowClasses_ClassWowClassId",
                        column: x => x.ClassWowClassId,
                        principalTable: "WowClasses",
                        principalColumn: "WowClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Raiders_WowRole_RoleWowRoleId",
                        column: x => x.RoleWowRoleId,
                        principalTable: "WowRole",
                        principalColumn: "WowRoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Raiders_WowSpecs_SpecId",
                        column: x => x.SpecId,
                        principalTable: "WowSpecs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WowClassWowRace",
                columns: table => new
                {
                    ClassesWowClassId = table.Column<int>(type: "int", nullable: false),
                    WowRacesWowRaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WowClassWowRace", x => new { x.ClassesWowClassId, x.WowRacesWowRaceId });
                    table.ForeignKey(
                        name: "FK_WowClassWowRace_Races_WowRacesWowRaceId",
                        column: x => x.WowRacesWowRaceId,
                        principalTable: "Races",
                        principalColumn: "WowRaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WowClassWowRace_WowClasses_ClassesWowClassId",
                        column: x => x.ClassesWowClassId,
                        principalTable: "WowClasses",
                        principalColumn: "WowClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RaiderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professions_Raiders_RaiderId",
                        column: x => x.RaiderId,
                        principalTable: "Raiders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professions_RaiderId",
                table: "Professions",
                column: "RaiderId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_WowFactionId",
                table: "Races",
                column: "WowFactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Raiders_ClassWowClassId",
                table: "Raiders",
                column: "ClassWowClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Raiders_MainId",
                table: "Raiders",
                column: "MainId");

            migrationBuilder.CreateIndex(
                name: "IX_Raiders_RaceWowRaceId",
                table: "Raiders",
                column: "RaceWowRaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Raiders_RankRaiderRankId",
                table: "Raiders",
                column: "RankRaiderRankId");

            migrationBuilder.CreateIndex(
                name: "IX_Raiders_RoleWowRoleId",
                table: "Raiders",
                column: "RoleWowRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Raiders_SpecId",
                table: "Raiders",
                column: "SpecId");

            migrationBuilder.CreateIndex(
                name: "IX_WowClassWowRace_WowRacesWowRaceId",
                table: "WowClassWowRace",
                column: "WowRacesWowRaceId");

            migrationBuilder.CreateIndex(
                name: "IX_WowClassWowSpec_WowSpecsId",
                table: "WowClassWowSpec",
                column: "WowSpecsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "WowClassWowRace");

            migrationBuilder.DropTable(
                name: "WowClassWowSpec");

            migrationBuilder.DropTable(
                name: "Raiders");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "RaiderRank");

            migrationBuilder.DropTable(
                name: "WowClasses");

            migrationBuilder.DropTable(
                name: "WowRole");

            migrationBuilder.DropTable(
                name: "WowSpecs");

            migrationBuilder.DropTable(
                name: "WowFaction");
        }
    }
}
