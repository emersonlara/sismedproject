using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.InfraData.Migrations;

public partial class AddFacebookVO : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Instagram",
            table: "Author");

        migrationBuilder.DropColumn(
            name: "Linkedin",
            table: "Author");

        migrationBuilder.DropColumn(
            name: "Medium",
            table: "Author");

        migrationBuilder.DropColumn(
            name: "Twitter",
            table: "Author");

        migrationBuilder.RenameColumn(
            name: "Youtube",
            table: "Author",
            newName: "Link");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "Link",
            table: "Author",
            newName: "Youtube");

        migrationBuilder.AddColumn<string>(
            name: "Instagram",
            table: "Author",
            type: "varchar(400)",
            maxLength: 400,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Linkedin",
            table: "Author",
            type: "varchar(400)",
            maxLength: 400,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Medium",
            table: "Author",
            type: "varchar(400)",
            maxLength: 400,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Twitter",
            table: "Author",
            type: "varchar(400)",
            maxLength: 400,
            nullable: true);
    }
}
