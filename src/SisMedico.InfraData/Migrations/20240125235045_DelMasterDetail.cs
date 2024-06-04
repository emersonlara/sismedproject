using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisMedico.InfraData.Migrations;

public partial class DelMasterDetail : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "TeamMembers");

        migrationBuilder.DropTable(
            name: "Teams");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Teams",
            columns: table => new
            {
                TeamID = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Description = table.Column<string>(type: "varchar(90)", nullable: true),
                Name = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Teams", x => x.TeamID);
            });

        migrationBuilder.CreateTable(
            name: "TeamMembers",
            columns: table => new
            {
                TeamMemberID = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Email = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                Name = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                TeamID = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TeamMembers", x => x.TeamMemberID);
                table.ForeignKey(
                    name: "FK_TeamMembers_Teams_TeamID",
                    column: x => x.TeamID,
                    principalTable: "Teams",
                    principalColumn: "TeamID",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_TeamMembers_TeamID",
            table: "TeamMembers",
            column: "TeamID");
    }
}
