using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.InfraData.Migrations;

public partial class ChangeVORedesSociaisInAuthorName : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "RedesSociais_Youtube",
            table: "Author",
            newName: "Youtube");

        migrationBuilder.RenameColumn(
            name: "RedesSociais_Twitter",
            table: "Author",
            newName: "Twitter");

        migrationBuilder.RenameColumn(
            name: "RedesSociais_Medium",
            table: "Author",
            newName: "Medium");

        migrationBuilder.RenameColumn(
            name: "RedesSociais_Linkedin",
            table: "Author",
            newName: "Linkedin");

        migrationBuilder.RenameColumn(
            name: "RedesSociais_Instagram",
            table: "Author",
            newName: "Instagram");

        migrationBuilder.RenameColumn(
            name: "RedesSociais_Facebook",
            table: "Author",
            newName: "Facebook");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "Youtube",
            table: "Author",
            newName: "RedesSociais_Youtube");

        migrationBuilder.RenameColumn(
            name: "Twitter",
            table: "Author",
            newName: "RedesSociais_Twitter");

        migrationBuilder.RenameColumn(
            name: "Medium",
            table: "Author",
            newName: "RedesSociais_Medium");

        migrationBuilder.RenameColumn(
            name: "Linkedin",
            table: "Author",
            newName: "RedesSociais_Linkedin");

        migrationBuilder.RenameColumn(
            name: "Instagram",
            table: "Author",
            newName: "RedesSociais_Instagram");

        migrationBuilder.RenameColumn(
            name: "Facebook",
            table: "Author",
            newName: "RedesSociais_Facebook");
    }
}
