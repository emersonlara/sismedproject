using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.InfraData.Migrations;

public partial class Del3CamposRedesSociais : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Instagram",
            table: "Author");

        migrationBuilder.DropColumn(
            name: "Medium",
            table: "Author");

        migrationBuilder.DropColumn(
            name: "Youtube",
            table: "Author");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "Instagram",
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
            name: "Youtube",
            table: "Author",
            type: "varchar(400)",
            maxLength: 400,
            nullable: true);
    }
}
