using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.InfraData.Migrations;

public partial class DeleteColumnSubject : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Subject",
            table: "Tags");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "Subject",
            table: "Tags",
            type: "varchar(90)",
            maxLength: 90,
            nullable: false,
            defaultValue: "");
    }
}
