using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.InfraData.Migrations;

public partial class AddMasterDetails : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Teams",
            columns: table => new
            {
                TeamID = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "varchar(90)", maxLength: 500, nullable: true),
                Description = table.Column<string>(type: "varchar(90)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Teams", x => x.TeamID);
            });

        migrationBuilder.CreateTable(
            name: "TeamMembers",
            columns: table => new
            {
                TeamMemberID = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                TeamID = table.Column<int>(nullable: false),
                Name = table.Column<string>(type: "varchar(90)", maxLength: 500, nullable: true),
                Email = table.Column<string>(type: "varchar(90)", maxLength: 500, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TeamMembers", x => x.TeamMemberID);
                table.ForeignKey(
                    name: "FK_TeamMembers_Teams_TeamID",
                    column: x => x.TeamID,
                    principalTable: "Teams",
                    principalColumn: "TeamID");
            });

        migrationBuilder.CreateIndex(
            name: "IX_TeamMembers_TeamID",
            table: "TeamMembers",
            column: "TeamID");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "TeamMembers");

        migrationBuilder.DropTable(
            name: "Teams");
    }
}
