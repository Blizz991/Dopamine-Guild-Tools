using Microsoft.EntityFrameworkCore.Migrations;

namespace WoW_Guild_Tools.Migrations
{
    public partial class UpdateWowClassDataLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Class",
                table: "Raiders",
                type: "nchar(11)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(8)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Class",
                table: "Raiders",
                type: "nchar(8)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(11)");
        }
    }
}
