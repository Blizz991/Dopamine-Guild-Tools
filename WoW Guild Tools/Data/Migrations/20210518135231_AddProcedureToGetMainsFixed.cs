using Microsoft.EntityFrameworkCore.Migrations;

namespace WoW_Guild_Tools.Migrations
{
    public partial class AddProcedureToGetMainsFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var storedProcedure = @"ALTER PROCEDURE [dbo].[GetMainRaiders]
                                    AS
                                    BEGIN
                                        SET NOCOUNT ON;
                                        SELECT * FROM Raiders WHERE MainId IS NULL
                                    END";

            migrationBuilder.Sql(storedProcedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
