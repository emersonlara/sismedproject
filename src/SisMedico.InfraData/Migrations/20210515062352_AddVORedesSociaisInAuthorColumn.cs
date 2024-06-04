using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.InfraData.Migrations;

public partial class AddVORedesSociaisInAuthorColumn : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "Medium",
            table: "Author",
            type: "varchar(400)",
            maxLength: 400,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "Medium",
            table: "Author",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(400)",
            oldMaxLength: 400,
            oldNullable: true);
    }
}
