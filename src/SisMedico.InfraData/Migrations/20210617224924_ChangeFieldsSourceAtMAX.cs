using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.InfraData.Migrations;

public partial class ChangeFieldsSourceAtMAX : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "SourceAt",
            table: "Tags",
            type: "nvarchar(MAX)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(1500)",
            oldMaxLength: 1500);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "SourceAt",
            table: "Tags",
            type: "varchar(1500)",
            maxLength: 1500,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(MAX)");
    }
}
