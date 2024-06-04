using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.InfraData.Migrations;

public partial class AddFacebookVO2 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Facebook",
            table: "Author");

        migrationBuilder.AddColumn<string>(
            name: "NameFace",
            table: "Author",
            type: "varchar(80)",
            maxLength: 400,
            nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "NameFace",
            table: "Author");

        migrationBuilder.AddColumn<string>(
            name: "Facebook",
            table: "Author",
            type: "varchar(400)",
            maxLength: 400,
            nullable: true);
    }
}
